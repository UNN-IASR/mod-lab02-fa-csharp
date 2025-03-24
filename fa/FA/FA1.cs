namespace fans;

public class FA1 : FA
{
    public FA1()
    {
        State notZeroNotOne = new State("notZeroNotOne", false);
        State zeroNotOne = new State("zeroNotOne", false);
        State moreZero = new State("moreZero", false);
        State notZeroOne = new State("notZeroOne", false);
        State zeroOne = new State("zeroOne", true);

        notZeroNotOne.Transitions.Add('0', zeroNotOne);
        notZeroNotOne.Transitions.Add('1', notZeroOne);

        zeroNotOne.Transitions.Add('0', moreZero);
        zeroNotOne.Transitions.Add('1', zeroOne);

        moreZero.Transitions.Add('0', moreZero);
        moreZero.Transitions.Add('1', moreZero);

        notZeroOne.Transitions.Add('0', zeroOne);
        notZeroOne.Transitions.Add('1', notZeroOne);

        zeroOne.Transitions.Add('0', moreZero);
        zeroOne.Transitions.Add('1', zeroOne);

        InitialState = notZeroNotOne;
    }
}