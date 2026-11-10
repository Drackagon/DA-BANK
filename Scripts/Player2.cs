using Godot;
using System;

public partial class Player2 : CharacterBody2D
{
	public const float Speed = 300.0f;

	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
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
