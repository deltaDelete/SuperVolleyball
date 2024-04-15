namespace SuperVolleyball;

public class UnitTest1 {
    public static readonly double Gravity = 9.8d;
    public static double BallTime(double velocity) {
        if (velocity < 0) {
            return 0;
            throw new Exception("Negative velocity");
        } 
        
        return 2 * velocity / Gravity;
    }
    
    [Fact]
    public void BallTime_NormalVelocity() {
        // Arrange
        var velocity = 9.8d;

        // Act
        var time = BallTime(velocity);
        
        // Assert
        Assert.Equal(2d, time);
    }

    [Fact]
    public void BallTime_NegativeVelocity() {
        // Arrange
        var velocity = -9.8d;
        
        // Act
        var time = BallTime(velocity);
        
        // Assert
        Assert.Equal(0d, time);
    }
}