using Godot;
using System;

public partial class Player2 : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float Deadzone = 0.2f;

	[Export]
	public int DeviceId { get; set; } = 1;

	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = new Vector2(
			Input.GetJoyAxis(DeviceId, JoyAxis.LeftX),
			Input.GetJoyAxis(DeviceId, JoyAxis.LeftY)
		);

		if (direction.Length() < Deadzone)
		{
			direction = Vector2.Zero;
		}
		else
		{
			direction = direction.Normalized();
		}

		if (direction == Vector2.Zero)
		{
			_animatedSprite.Play("Idle");
		}
		else
		{
			if (Mathf.Abs(direction.X) >= Mathf.Abs(direction.Y))
			{
				if (direction.X > 0)
				{
					_animatedSprite.Play("Right");
					_animatedSprite.FlipH = false;
				}
				else if (direction.X < 0)
				{
					_animatedSprite.Play("Left");
					_animatedSprite.FlipH = false;
				}
			}
			else
			{
				if (direction.Y > 0)
				{
					_animatedSprite.Play("Down");
				}
				else if (direction.Y < 0)
				{
					_animatedSprite.Play("Up");
				}
			}
		}

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
