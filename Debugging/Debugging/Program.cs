using System.Diagnostics;
public class Solution {
    struct Point
    {
        public int x;
        public int y;
    }
    static void Main(){
        char[][] grid = new char[][] {
            new [] {'1','1','0','0','0'},
            new [] {'1','1','0','0','0'},
            new [] {'0','0','0','0','0'},
            new [] {'0','0','0','1','1'},
        };
        Console.WriteLine(NumIslands(grid));
    }
    public static int NumIslands(char[][] grid) {
        
        int num = 0;
        bool[][] visited = new bool[grid.Length][];
        for(int i = 0; i < grid.Length; i++)
            visited[i] = new bool[grid[i].Length];
        
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                visited[i][j] = true;
                if(grid[i][j] == '1')
                {
                    num++;
                    Trace(grid, i, j, visited);
                }
            }
        }
        
        return num;
    }
    
    static void Trace(char[][] grid, int i, int j, bool[][] visited)
    {
        if(i-1 >= 0 && grid[i-1][j] == '1' && !visited[i-1][j]) 
            Trace(grid, i-1, j, visited);
        if(i+1 < grid.Length && grid[i+1][j] == '1' && !visited[i+1][j]) 
            Trace(grid, i+1, j, visited);
        if(j-1 >= 0 && grid[i][j-1] == '1' && !visited[i][j-1]) 
            Trace(grid, i, j-1, visited);
        if(j+1 < grid[i].Length && grid[i][j+1] == '1' && !visited[i][j+1]) 
            Trace(grid, i, j+1, visited);
    }
}