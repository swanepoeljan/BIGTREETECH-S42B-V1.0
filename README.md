# TrueStepMini

This is a fork of [TrueStep](https://github.com/swanepoeljan/TrueStep) which itself is a fork of [BIGTREETECH-S42B-V1.0](https://github.com/bigtreetech/BIGTREETECH-S42B-V1.0). The goal of this fork is to prune any unnecessary sources from the firmware itself, and to clean up the build so that I understand what is going on. This is largely an exploratory activity to develop familiarity with what libraries are needed to run the S42B_V1.0 hardware, but it may be useful to other folks seeking to work in this code as well.

At the time of writing, these sources compile with `pio run`. I have not yet attempted to run them on a device.

After I develop a familiarity with the hardware, I am contemplating starting a totally new firmware with a HAL and proper licensing that could be run on other devices such as the S42B_V2.0. If BTT is able to issue proper licensing for their source files I would also consider doing this work in this library.