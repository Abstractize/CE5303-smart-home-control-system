echo "--> Exporting all GPIO pins ..."
for pin in 2 3 4 17 27 22 10 9 11
do
  echo $pin >> /sys/class/gpio/export
done

# Run
echo "--> Running API ..."
${dotnet} API.dll
