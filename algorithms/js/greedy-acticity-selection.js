// Problem Statement: we are given 'n' activities with their start and end finish times.
// Select the maximum number of activities that can be performed by a single person, assuming that
// a person, assuming that a person can only work on a single activity at a time

const stubActivities = [
    [0, 6],
    [3, 4],
    [1, 2],
    [5, 8],
    [5, 7],
    [8, 9]
]

const activitySelection = (activities) => {
    const result = [];

    activities.sort((a, b) => a[1] - b[1]);

    let previousActivity = activities[0];
    result.push(previousActivity);

    for(let i = 1; i < activities.length; i++) {
        if(previousActivity[1] < activities[i][0]) {
            result.push(activities[i]);
            previousActivity = activities[i];
        }
    }

    return result;
}

const res = activitySelection(stubActivities);
console.log(res);
