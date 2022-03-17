if not defined in_subprocess (cmd /k set in_subprocess=y ^& %0 %*) & exit )

usbipd wsl attach -d Ubuntu-18.04 -b 2-11