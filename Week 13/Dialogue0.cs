
public class Dialogue0 : DialogueHandling
{
    private readonly string streamA = "Oh no! My cabbages!";
    private readonly string streamB = "Why are there so many monsters?";
    private readonly string streamC = "Eeep! Stop that!";

    protected override void BuildDialogueStream()
    {
        CreateDialogueTree(streamA, streamB, streamC);
    }
}
