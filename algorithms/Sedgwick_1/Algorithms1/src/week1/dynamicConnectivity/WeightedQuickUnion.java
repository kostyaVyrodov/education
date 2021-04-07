package week1.dynamicConnectivity;

import java.util.Arrays;
import java.util.stream.IntStream;

public class WeightedQuickUnion {
    public int[] data;
    public int[] weights;

    public WeightedQuickUnion(int N) {
        data = IntStream.range(0, N).toArray();
        Arrays.fill(weights, 1);
    }

    private int root(int e) {
        while (e != data[e]) {
            // Path compression
            data[e] = data[data[e]];
            e = data[e];
        }

        return e;
    }

    public boolean connected(int e1, int e2) {
        return root(e1) == root(e2);
    }

    public void union(int e1, int e2) {
        int r1 = root(e1);
        int r2 = root(e2);

        if (r1 == r2) {
            return;
        }

        if (weights[r1] > weights[r2]) {
            data[r2] = data[r1];
            weights[r1] += weights[r2];
        } else {
            data[r1] = data[r2];
            weights[r2] += weights[r1];
        }
    }
}
