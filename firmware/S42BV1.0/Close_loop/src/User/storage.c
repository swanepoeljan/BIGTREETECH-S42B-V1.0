#include "storage.h"

uint16_t STMFLASH_BUF[STM_SECTOR_SIZE / 2];

void STMFLASH_Read(uint32_t ReadAddr, uint16_t *pBuffer, uint16_t NumToRead)
{
	for (uint16_t i = 0; i < NumToRead; i++)
	{
		pBuffer[i] = FlashReadHalfWord(ReadAddr); //
		ReadAddr += 2;							  //
	}
}

void STMFLASH_Write_NoCheck(uint32_t WriteAddr, uint16_t *pBuffer, uint16_t NumToWrite)
{
	for (uint16_t i = 0; i < NumToWrite; i++)
	{
		FlashWriteHalfWord(WriteAddr, pBuffer[i]);
		WriteAddr += 2; //
	}
}

void STMFLASH_Write(uint32_t WriteAddr, uint16_t *pBuffer, uint16_t NumToWrite)
{
	uint32_t secpos;	// Sector position
	uint16_t secoff;	//
	uint16_t secremain; //
	uint16_t i;
	uint32_t offaddr; //

	// Check if arguments are valid
	if (WriteAddr < STM32_FLASH_BASE || (WriteAddr >= (STM32_FLASH_BASE + 1024 * STM32_FLASH_SIZE)))
		return;

	FlashUnlock();
	offaddr = WriteAddr - STM32_FLASH_BASE;	  //
	secpos = offaddr / STM_SECTOR_SIZE;		  //
	secoff = (offaddr % STM_SECTOR_SIZE) / 2; //
	secremain = STM_SECTOR_SIZE / 2 - secoff; //

	if (NumToWrite <= secremain)
		secremain = NumToWrite; //

	while (1)
	{
		STMFLASH_Read(secpos * STM_SECTOR_SIZE + STM32_FLASH_BASE, STMFLASH_BUF, STM_SECTOR_SIZE / 2); //
		for (i = 0; i < secremain; i++)
		{
			if (STMFLASH_BUF[secoff + i] != 0XFFFF)
				break;
		}
		if (i < secremain)
		{
			FlashErasePage(secpos * STM_SECTOR_SIZE + STM32_FLASH_BASE);
			for (i = 0; i < secremain; i++)
			{
				STMFLASH_BUF[i + secoff] = pBuffer[i];
			}
			STMFLASH_Write_NoCheck(secpos * STM_SECTOR_SIZE + STM32_FLASH_BASE, STMFLASH_BUF, STM_SECTOR_SIZE / 2); //
		}
		else
			STMFLASH_Write_NoCheck(WriteAddr, pBuffer, secremain);

		if (NumToWrite == secremain)
			break;
		else
		{
			secpos++;	//
			secoff = 0; //
			pBuffer += secremain;
			WriteAddr += secremain * 2; //
			NumToWrite -= secremain;	//

			if (NumToWrite > (STM_SECTOR_SIZE / 2))
				secremain = STM_SECTOR_SIZE / 2;
			else
				secremain = NumToWrite;
		}
	};
	FlashLock();
}

void StoreCurrentParameters()
{
	LED_H;

	tblParams[0] = 0xAA;
	tblParams[1] = currentLimit;
	//table1[2]   = 16;
	tblParams[3] = stepangle;
	//table1[4]   = 3;
	tblParams[5] = Motor_ENmode_flag;
	//table1[6]   = 1;
	tblParams[7] = Motor_Dir;
	//table1[8]   = 1;
	tblParams[11] = kp;
	tblParams[12] = ki;
	tblParams[13] = kd;
	tblParams[14] = closemode;

	NVIC_DisableIRQ(USART1_IRQn);
	STMFLASH_Write(DATA_STORE_ADDR, tblParams, sizeof(tblParams));
	NVIC_EnableIRQ(USART1_IRQn);

	LL_mDelay(250);
	LED_L;
}