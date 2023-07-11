using System.Device.Gpio;

namespace HardwareTest
{
    internal class InvertGpioPin
    {
        private GpioPin _Pin;

        public InvertGpioPin(GpioPin pin)
        {
            _Pin = pin;
        }

        public PinValue Read()
        {
            return (PinValue)(1 - (int)_Pin.Read());
        }

        public void Write(PinValue value)
        {
            _Pin.Write((PinValue)(1 - (int)value));
        }

    }
}
