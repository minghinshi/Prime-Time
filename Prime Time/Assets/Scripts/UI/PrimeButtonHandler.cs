using UnityEngine;

public class PrimeButtonHandler
{
    private GameObject buttonPrefab = (GameObject)Resources.Load("Prefabs/PrimeButton");
    private Transform buttonContainer;

    public PrimeButtonHandler()
    {
        buttonContainer = GameObject.Find("PrimeSelector").transform;
    }

    public PrimeButton[] GetNewButtons(PrimeRange primeRange)
    {
        DeleteButtons();
        int[] primes = primeRange.GetPrimesInRange();
        PrimeButton[] primeButtons = new PrimeButton[primes.Length];
        for (int i = 0; i < primes.Length; i++)
            primeButtons[i] = GetNewButton(primes[i]);
        return primeButtons;
    }

    private PrimeButton GetNewButton(int prime)
    {
        GameObject buttonObject = Object.Instantiate(buttonPrefab, buttonContainer);
        PrimeButton primeButton = buttonObject.GetComponent<PrimeButton>();
        primeButton.Initialize(prime);
        return primeButton;
    }

    private void DeleteButtons()
    {
        foreach (Transform child in buttonContainer)
            Object.Destroy(child.gameObject);
    }
}
