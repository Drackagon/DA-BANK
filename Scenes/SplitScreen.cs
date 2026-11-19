using Godot;

public partial class SplitScreen : Node
{
	private SubViewport _subViewport1;
	private SubViewport _subViewport2;

	public override void _Ready()
	{
		_subViewport1 = GetNode<SubViewport>("GridContainer/SubViewportContainer/SubViewport1");
		_subViewport2 = GetNode<SubViewport>("GridContainer/SubViewportContainer2/SubViewport2");

		_subViewport2.World2D = _subViewport1.World2D;
	}
}
