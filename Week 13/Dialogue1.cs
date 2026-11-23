public class Dialogue1 : DialogueHandling
{
    private readonly string streamA = "Please protect me!!!";
    private readonly string streamB = "Where are all these monsters coming from?";
    private readonly string streamC = "Hurry protect the village!";

    protected override void BuildDialogueStream()
    {
        CreateDialogueTree(streamA, streamB, streamC);
    }
}
