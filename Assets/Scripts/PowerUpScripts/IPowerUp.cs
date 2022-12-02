using System.Collections;

public interface IPowerUp
{
    public float PowerUpDuration { get; set; }
    public void PowerUp(PlayerController player);

    public IEnumerator Duration(PlayerController player);
}
