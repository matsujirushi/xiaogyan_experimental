using System.Device.Gpio;
using System.Threading;

namespace HardwareTest
{
    public class Program
    {
        private const int _LedPin = 21;
        private const int _ButtonAPin = 9;
        private const int _ButtonBPin = 20;

        public static void Main()
        {
            using var gpio = new GpioController();

            using var ledRaw = gpio.OpenPin(_LedPin, PinMode.Output);
            var led = new InvertGpioPin(ledRaw);

            using var buttonARaw = gpio.OpenPin(_ButtonAPin, PinMode.InputPullUp);
            using var buttonBRaw = gpio.OpenPin(_ButtonBPin, PinMode.InputPullUp);
            var buttonA = new InvertGpioPin(buttonARaw);
            var buttonB = new InvertGpioPin(buttonBRaw);

            while (true)
            {
                if (buttonA.Read() != 0)
                {
                    led.Write(1);
                }
                else
                {
                    led.Write(0);
                }

                Thread.Sleep(100);
            }
        }
    }
}
