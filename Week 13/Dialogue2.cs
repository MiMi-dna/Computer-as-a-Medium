public class Dialogue2 : DialogueHandling
{
    //enemy dialogue
    private readonly string streamA = "You think you can defeat us!?";
    private readonly string streamB = "Aaargh!";
    private readonly string streamC = "You don't stand a chance!";

    protected override void BuildDialogueStream()
    {
        CreateDialogueTree(streamA, streamB, streamC);
    }
}