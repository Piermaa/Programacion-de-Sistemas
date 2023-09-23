using System;

public class Chase : Agent
{
    private void FixedUpdate()
    {
        if (_isCurrentAgent)
        {
            NextWaypoint(); // para que vuelva a guardar la pos del player
        }
    }
}
