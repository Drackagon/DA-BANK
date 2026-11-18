using Godot;

public partial class SplitScreen : CanvasLayer // Rename class to match your .cs file name
{
	[Export]
	public Node2D Player1 { get; set; }

	[Export]
	public Node2D Player2 { get; set; }

	private SubViewport _subViewport0;
	private SubViewport _subViewport1;

	public override async void _Ready()
	{
		_subViewport0 = GetNode<SubViewport>("%SubViewport0");
		_subViewport1 = GetNode<SubViewport>("%SubViewport1");

		World2D currentWorld = GetTree().Root.World2D;
		_subViewport0.World2D = currentWorld;
		_subViewport1.World2D = currentWorld;

		await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

		Player1.Reparent(_subViewport0);
		Player2.Reparent(_subViewport1);
	}
}
