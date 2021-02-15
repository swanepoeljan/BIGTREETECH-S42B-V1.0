#ifndef __DISPLAY_H
#define __DISPLAY_H


#include "main.h"

struct Menu menuMain;

// Create the menu
void BuildMenu(void);

void Motor_data_dis(void);

void ShowStartupScreen(void);

void ShowInfoScreen(void);

void ShowCalibrateScreen(void);

void ShowCalibrateOKScreen(void);

void ShowCalibrateCompleteScreen(void);

void ShowBootloaderScreen(void);

void ShowEncoderError(void);

#endif

