namespace fans;

public class FA3 : FA
{
    public FA3()
    {
        State start = new State("start", false);
        State partial = new State("partial", false);
        State completed = new State("completed", true);

        start.Transitions.Add('0', start);
        start.Transitions.Add('1', partial);

        partial.Transitions.Add('0', start);
        partial.Transitions.Add('1', completed);

        completed.Transitions.Add('0', completed);
        completed.Transitions.Add('1', completed);

        InitialState = start;
    }
}