using System;
using System.Device.Gpio;

namespace HardwareTest
{
    internal class Xiaogyan : IDisposable
    {
        public InvertGpioPin Led;
        public InvertGpioPin ButtonA;
        public InvertGpioPin ButtonB;

        public void begin()
        {
            var gpio = new GpioController();

            _LedRaw = gpio.OpenPin(_LedPin, PinMode.Output);
            _ButtonARaw = gpio.OpenPin(_ButtonAPin, PinMode.InputPullUp);
            _ButtonBRaw = gpio.OpenPin(_ButtonBPin, PinMode.InputPullUp);

            Led = new InvertGpioPin(_LedRaw);
            ButtonA = new InvertGpioPin(_ButtonARaw);
            ButtonB = new InvertGpioPin(_ButtonBRaw);
        }

        public void Dispose()
        {
            _LedRaw?.Dispose();
            _LedRaw = null;
            _ButtonARaw?.Dispose();
            _ButtonARaw = null;
            _ButtonBRaw?.Dispose();
            _ButtonBRaw = null;
        }

        private const int _LedPin = 21;
        private const int _ButtonAPin = 9;
        private const int _ButtonBPin = 20;

        private GpioPin _LedRaw;
        private GpioPin _ButtonARaw;
        private GpioPin _ButtonBRaw;

    }
}
