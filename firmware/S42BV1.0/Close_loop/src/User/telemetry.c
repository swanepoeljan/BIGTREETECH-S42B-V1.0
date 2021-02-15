#include "telemetry.h"
#include "serial.h"
#include "usart.h"
#include "main.h"

// TODO:
// - Make it more generic for future use.

uint32_t prevStreamTickCount;

// Stream Angle and AngleError to serial port
void StreamAngle()
{
  if (tickCount < (prevStreamTickCount + 5))
    return;

  struct Serial_Msg_Angle streamAngle;
  // Use 'y' which is read in the controller loop
  streamAngle.angle = (float)y;  
  
  uint8_t len = Serial_GeneratePacket(SERIAL_MSG_ANGLE, (uint8_t *)&streamAngle, sizeof(streamAngle));
  UART1_Write(packetBuffer, len);

  struct Serial_Msg_AngleError ae;
  ae.error = pid_error * 0.021972;

  len = Serial_GeneratePacket(SERIAL_MSG_ANGERROR, (uint8_t *)&ae, sizeof(ae));
  UART1_Write(packetBuffer, len);

  prevStreamTickCount = tickCount;
}