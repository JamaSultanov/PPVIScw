using System;

namespace DependencyInjection;

// An interface for the library
interface IGamepadFunctionality
{
    string GetGamepadName();
    void SetVibrationPower(float InPower);
}

// Concrete implementation of the Xbox controller functionality
class XBoxGamepad : IGamepadFunctionality
{
    readonly string GamepadName = "Xbox controller";
    float VibrationPower = 1.0f;
    public string GetGamepadName() => GamepadName;
    public void SetVibrationPower(float InPower) => VibrationPower = Math.Clamp(InPower, 0.0f, 1.0f);

}

// Concrete implementation of the PlayStation controller functionality
class PlaystationJoystick : IGamepadFunctionality
{
    readonly string ControllerName = "PlayStation controller";
    float VibratingPower = 100.0f;
    public string GetGamepadName() => ControllerName;
    public void SetVibrationPower(float InPower) => VibratingPower = Math.Clamp(InPower * 100.0f, 0.0f, 100.0f);
}

// Concrete implementation of the Steam controller functionality
class SteamController : IGamepadFunctionality
{
    readonly string JoystickName = "Steam controller";
    double Vibrating = 1.0;
    public string GetGamepadName() => JoystickName;
    public void SetVibrationPower(float InPower) => Vibrating = Convert.ToDouble(Math.Clamp(InPower, 0.0f, 1.0f));
}

// An interface for gamepad functionality injections
interface IGamepadFunctionalityInjector
{
    void InjectFunctionality(IGamepadFunctionality InGamepadFunctionality);
}

class CGamepad : IGamepadFunctionalityInjector
{
    IGamepadFunctionality _GamepadFunctionality;

    public CGamepad()
    {

    }

    // Constructor injection
    public CGamepad(IGamepadFunctionality InGamepadFunctionality) => _GamepadFunctionality = InGamepadFunctionality;

    // Setter injection
    public void SetGamepadFunctionality(IGamepadFunctionality InGamepadFunctionality) => _GamepadFunctionality = InGamepadFunctionality;

    // Interface injection
    public void InjectFunctionality(IGamepadFunctionality InGamepadFunctionality) => _GamepadFunctionality = InGamepadFunctionality;

    public void Showcase()
    {
        var message = string.Format("We're using the {0} right now, do you want to change the vibrating power?\r\n", _GamepadFunctionality.GetGamepadName());
        Console.WriteLine(message);
    }
}

enum Platforms : byte
{
    Xbox,
    Playstation,
    Steam
}

class CGameEngine {
    private Platforms _platform;
    private CGamepad _gamepad;

    public void SetPlatform(Platforms inPlatform)
    {
        _platform = inPlatform;
        switch (_platform)
        {
            case Platforms.Xbox:

                // injects dependency on XBoxGamepad class through Constructor Injection
                _gamepad = new CGamepad(new XBoxGamepad());
                break;
            case Platforms.Playstation:
                _gamepad = new CGamepad();

                // injects dependency on PlaystationJoystick class through Setter Injection
                _gamepad.SetGamepadFunctionality(new PlaystationJoystick());
                break;
            case Platforms.Steam:
                _gamepad = new CGamepad();
                // injects dependency on SteamController class through Interface Injection
                _gamepad.InjectFunctionality(new SteamController());
                break;
        }

        _gamepad.Showcase();
    }
}

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        var Engine = new CGameEngine();
        Engine.SetPlatform(Platforms.Steam);
        Engine.SetPlatform(Platforms.Xbox);
        Engine.SetPlatform(Platforms.Playstation);
    }
}