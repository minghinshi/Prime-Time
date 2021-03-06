using UnityEngine;

public class InputHandler
{
    private CurrentPrimeInputs primeInput;
    private Round round;

    public InputHandler() {
        InitializeActionButtons();
    }

    public void SetUpInputFor(Round round) {
        this.round = round;
        primeInput = round.PrimeInput;
        InitializePrimeButtons(round.GetPrimeRange());
    }

    private void InitializeActionButtons() {
        ActionButton submitButton = GameObject.Find("SubmitButton").GetComponent<ActionButton>();
        submitButton.ActionButtonClick += OnSubmitButtonClick;

        ActionButton undoButton = GameObject.Find("UndoButton").GetComponent<ActionButton>();
        undoButton.ActionButtonClick += OnUndoButtonClick;
    }

    private void InitializePrimeButtons(PrimeRange primeRange)
    {
        PrimeButton[] primeButtons = new PrimeButtonHandler().GetNewButtons(primeRange);
        foreach (PrimeButton button in primeButtons)
            button.PrimeButtonClick += OnPrimeButtonClick;
    }

    private void OnPrimeButtonClick(object sender, int prime)
    {
        primeInput.AddPrime(prime);
    }

    private void OnUndoButtonClick(object sender, System.EventArgs e)
    {
        primeInput.DeletePrime();
    }

    private void OnSubmitButtonClick(object sender, System.EventArgs e)
    {
        round.MakeAttempt();
    }
}
