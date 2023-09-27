using Godot;
using System;

public partial class Camera3D : Godot.Camera3D
{
    private Vector2 sensitivity = new Vector2(0.002f, 0.002f);
    private float rotation = 0.0f;
    private float acceleration = 10.0f;
    private float maxSpeed = 50.0f;
    private float friction = 0.1f;
    private Vector3 speed3D = Vector3.Zero;

    private Vector2 mouseInput = Vector2.Zero;
    private Vector3 velocity = Vector3.Zero;
    private Vector3 targetRotation = Vector3.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseEvent)
        {
            Vector2 mouseDirection = mouseEvent.Position - GetViewport().GetVisibleRect().Size / 2;
            //var mouse_direction = Vector2(mouseEvent.GlobalPosition.X - get_viewport().size / 2, mouseEvent.GlobalPosition.Y - get_viewport().size / 2);
            mouseInput = mouseDirection * sensitivity;
        }

        // Receives mouse button input
        if (@event is InputEventMouseButton)
        {
            /*var mouseButtonEvent = (InputEventMouseButton)@event;
            switch (mouseButtonEvent.ButtonIndex)
            {
                case (int)ButtonList.Right:
                    // Only allows rotation if right click down
                    Input.SetMouseMode(mouseButtonEvent.Pressed ? Input.MouseMode.Captured : Input.MouseMode.Visible);
                    break;
                case (int)ButtonList.WheelUp:
                    // Increases max velocity
                    _velMultiplier = Mathf.Clamp(_velMultiplier * 1.1f, 0.2f, 20f);
                    break;
                case (int)ButtonList.WheelDown:
                    // Decreases max velocity
                    _velMultiplier = Mathf.Clamp(_velMultiplier / 1.1f, 0.2f, 20f);
                    break;
            }*/
        }

        // Receives key input
        if (@event is InputEventKey)
        {
            var keyEvent = (InputEventKey)@event;
            switch (keyEvent.Keycode)
            {
                case Key.W:
                    //_w = keyEvent.Pressed;
                    break;
                case Key.S:
                    //_s = keyEvent.Pressed;
                    break;
                case Key.A:
                    //_a = keyEvent.Pressed;
                    break;
                case Key.D:
                    //_d = keyEvent.Pressed;
                    break;
                case Key.Q:
                    //_q = keyEvent.Pressed;
                    break;
                case Key.E:
                    //_e = keyEvent.Pressed;
                    break;
                case Key.Shift:
                    //_shift = keyEvent.Pressed;
                    break;
                case Key.Alt:
                    //_alt = keyEvent.Pressed;
                    break;
            }
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        _UpdateMouselook(delta);
        _UpdateMovement(delta);

        /*Vector3 direction = Vector3.Zero;

        if (Input.IsActionPressed("move_forward"))
            direction -= Transform.Basis.Z;

        if (Input.IsActionPressed("move_backward"))
            direction += Transform.Basis.Z;

        if (Input.IsActionPressed("move_left"))
            direction -= Transform.Basis.X;

        if (Input.IsActionPressed("move_right"))
            direction += Transform.Basis.X;

        direction = direction.Normalized();

        RotateX(-mouseInput.Y);
        RotateY(-mouseInput.X);

        mouseInput = Vector2.Zero;

        velocity += direction * moveSpeed * (float)delta;

        velocity = velocity.Lerp(Vector3.Zero, friction * (float)delta);

        Translate(velocity * (float)delta);

        targetRotation.X = Mathf.LerpAngle(targetRotation.X, 0f, 0.1f);
        targetRotation.Y = Mathf.LerpAngle(targetRotation.Y, 0f, 0.1f);

        RotationDegrees = targetRotation;*/
    }

    private void _UpdateMovement(double delta)
    {
        Vector3 direction = Vector3.Zero;

        if (Input.IsActionPressed("move_forward"))
            direction -= Transform.Basis.Z;

        if (Input.IsActionPressed("move_backward"))
            direction += Transform.Basis.Z;

        if (Input.IsActionPressed("move_left"))
            direction -= Transform.Basis.X;

        if (Input.IsActionPressed("move_right"))
            direction += Transform.Basis.X;

        direction = direction.Normalized();

        velocity += direction * acceleration * (float)delta;
        velocity = velocity.Lerp(Vector3.Zero, velocity.Length() * friction * (float)delta);

        if (velocity.Length() > maxSpeed)
            velocity = velocity.Normalized() * maxSpeed;

        Translate(velocity * (float)delta);
    }

    private void _UpdateMouselook(double delta)
    {
        float intensity = 1f * (float)delta;
        float invertIntensity = 1 - intensity;
        rotation = rotation * invertIntensity + intensity * mouseInput.X;
        Rotation = Vector3.Zero;
        RotateZ(rotation);
        //RotateY(-mouseInput.Y * (float)delta);

        //RotateX(-mouseInput.Y);
        //RotateY(-mouseInput.X);

        //mouseInput = Vector2.Zero;
        /*
        targetRotation.X = Mathf.LerpAngle(targetRotation.X, 0f, 0.1f);
        targetRotation.Y = Mathf.LerpAngle(targetRotation.Y, 0f, 0.1f);

        RotationDegrees = targetRotation;*/

    }
}
