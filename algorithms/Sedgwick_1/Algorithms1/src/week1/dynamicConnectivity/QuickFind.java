package week1.dynamicConnectivity;

import java.util.stream.IntStream;

public class QuickFind {
    private int[] data;

    public QuickFind(int N) {
        data = IntStream.range(0, N).toArray();
    }

    public boolean connected(int p, int q) {
        return data[p] == data[q];
    }

    public void union(int childIndex, int parentIndex) {
        int childV = data[childIndex];
        int parentV = data[parentIndex];

        for(int i = 0; i < data.length; i++) {
            if(data[i] == childV) {
                data[i] = parentV;
            }
        }
    }
}
