namespace fans;

public class FA2 : FA
{
    public FA2()
    {
        State evenZeroEvenOne = new State("evenZeroEvenOne", false);
        State oddZeroEvenOne = new State("oddZeroEvenOne", false);
        State evenZeroOddOne = new State("evenZeroOddOne", false);
        State oddZeroOddOne = new State("oddZeroOddOne", true);

        evenZeroEvenOne.Transitions.Add('0', oddZeroEvenOne);
        evenZeroEvenOne.Transitions.Add('1', evenZeroOddOne);

        oddZeroEvenOne.Transitions.Add('0', evenZeroEvenOne);
        oddZeroEvenOne.Transitions.Add('1', oddZeroOddOne);

        evenZeroOddOne.Transitions.Add('0', oddZeroOddOne);
        evenZeroOddOne.Transitions.Add('1', evenZeroEvenOne);

        oddZeroOddOne.Transitions.Add('0', evenZeroOddOne);
        oddZeroOddOne.Transitions.Add('1', oddZeroEvenOne);

        InitialState = evenZeroEvenOne;
    }
}