public class CustomGrid
{
    private int width;
    private int height;
    private int[,] gridArray;

    public CustomGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
        gridArray = new int[width, height];
    }
}