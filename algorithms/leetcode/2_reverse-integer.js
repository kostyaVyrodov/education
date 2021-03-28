var reverse = function (x) {
    let isNegative = false;
    let maxInt = Math.pow(2, 31) - 1 
    if (x < 0) {
        isNegative = true
        x = x * -1
    }

    let res = 0;
    while (x > 0) {
        const tail = x % 10
        res *= 10
        res += tail
        x = Math.floor(x / 10)
    }
    debugger;
    if (isNegative) {
        return res > maxInt ? 0 : (res * -1);
    }

    return res > maxInt ? 0 : res;
};

reverse(123)
