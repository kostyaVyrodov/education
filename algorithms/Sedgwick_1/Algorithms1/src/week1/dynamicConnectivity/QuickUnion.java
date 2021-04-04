package week1.dynamicConnectivity;

import java.util.stream.IntStream;

public class QuickUnion {
    private int[] data;

    public QuickUnion(int N) {
        data = IntStream.range(0, N).toArray();
    }

    private int root(int i)   {
        while (i != data[i]) {
            i = data[i];
        }

        return i;
    }

    public boolean connected(int p, int q) {
        return root(p) == root(q);
    }

    public void union(int p, int q) {
        int childIndex = root(p);
        int parentIndex = root(q);

        data[childIndex] = data[parentIndex];
    }
}
