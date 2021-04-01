var reverse = function (x) {
    const maxInt = Math.pow(2, 31) - 1
    const minInt = Math.pow(-2, 31)

    let res = 0

    while (x != 0) {
        const pop = x % 10
        res *= 10
        res += pop
        x = Math.trunc(x / 10)
    }

    return (minInt < res && res < maxInt) ? res : 0;
};
