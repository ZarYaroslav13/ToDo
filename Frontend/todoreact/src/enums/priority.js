export const Priority = {
    NONE: { name: "None", value: 0 },
    LOW: { name: "Low", value: 1 },
    MEDIUM: { name: "Medium", value: 2 },
    HIGH: { name: "High", value: 3 }
};

export const PriorityFunctions = {

    fromValue(value) {
        return Object.values(Priority).find(p => p.value === value) || Priority.NONE;
    },

    fromName(name) {
        return Object.values(Priority).find(p => p.name.toLowerCase() === name.toLowerCase()) || Priority.NONE;
    },

    toString(priority) {
        return priority?.name || Priority.NONE.name;
    },

    toValue(priority) {
        return typeof priority === "number"
            ? priority
            : priority?.value ?? Priority.NONE.value;
    }
};
