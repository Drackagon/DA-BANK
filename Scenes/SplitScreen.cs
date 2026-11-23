using Godot;

public partial class SplitScreen : Node
{
	private SubViewport _subviewport1;
	private SubViewport _subviewport2;
	private SubViewport _subviewport3;
	private SubViewport _subviewport4;

	public override void _Ready()
	{
		_subviewport1 = GetNode<SubViewport>("GridContainer/SubViewportContainer/SubViewport1");
		_subviewport2 = GetNode<SubViewport>("GridContainer/SubViewportContainer2/SubViewport2");
		_subviewport3 = GetNode<SubViewport>("GridContainer/SubViewportContainer3/SubViewport3");
		_subviewport4 = GetNode<SubViewport>("GridContainer/SubViewportContainer4/SubViewport4");

		_subviewport2.World2D = _subviewport1.World2D;
		_subviewport3.World2D = _subviewport1.World2D;
		_subviewport4.World2D = _subviewport1.World2D;
	}
}
