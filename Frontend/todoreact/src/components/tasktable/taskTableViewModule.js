import { useState, useMemo } from "react";
import { Priority, PriorityFunctions } from "../../enums/priority";

function descendingComparator(a, b, orderBy) {
    let aValue = a[orderBy];
    let bValue = b[orderBy];

    if (orderBy === "priority") {
        aValue = PriorityFunctions.toValue(aValue);
        bValue = PriorityFunctions.toValue(bValue);
    }

    if (bValue < aValue) return -1;
    if (bValue > aValue) return 1;
    return 0;
}

function getComparator(order, orderBy) {
    return order === "desc"
        ? (a, b) => descendingComparator(a, b, orderBy)
        : (a, b) => -descendingComparator(a, b, orderBy);
}

export function useTasksViewModel(tasks, onAddCallback) {
    const [order, setOrder] = useState("asc");
    const [orderBy, setOrderBy] = useState("title");
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);
    const [filter, setFilter] = useState("");
    const [priorityFilter, setPriorityFilter] = useState([]);
    const [startDate, setStartDate] = useState("");
    const [endDate, setEndDate] = useState("");

    const PriorityFilterVariants = {
        All: "All",
        ...Object.fromEntries(
            Object.values(Priority)
                .filter(p => p?.name)
                .map(p => [p.name, p.name])
        ),
    };

    const handleRequestSort = (_, property) => {
        const isAsc = orderBy === property && order === "asc";
        setOrder(isAsc ? "desc" : "asc");
        setOrderBy(property);
    };

    const handleChangePage = (_, newPage) => setPage(newPage);
    const handleChangeRowsPerPage = (event) => {
        setRowsPerPage(parseInt(event.target.value, 10));
        setPage(0);
    };

    const filteredTasks = useMemo(() => {
        return tasks.filter((t) => {
            const matchesTitle = t.title?.toLowerCase().includes(filter.toLowerCase());
            const matchesPriority =
                priorityFilter.length === 0 ||
                priorityFilter.includes("All") ||
                priorityFilter.includes(t.priority.name);

            let matchesDeadline = true;
            if (startDate) matchesDeadline = new Date(t.deadline) >= new Date(startDate);
            if (endDate) matchesDeadline = matchesDeadline && new Date(t.deadline) <= new Date(endDate);

            return matchesTitle && matchesPriority && matchesDeadline;
        });
    }, [tasks, filter, priorityFilter, startDate, endDate]);

    const visibleRows = useMemo(() => {
        return [...filteredTasks]
            .sort(getComparator(order, orderBy))
            .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage);
    }, [filteredTasks, order, orderBy, page, rowsPerPage]);

    return {
        order,
        orderBy,
        page,
        rowsPerPage,
        filter,
        setFilter,
        priorityFilter,
        setPriorityFilter,
        startDate,
        setStartDate,
        endDate,
        setEndDate,
        handleRequestSort,
        handleChangePage,
        handleChangeRowsPerPage,
        filteredTasks,
        visibleRows,
        PriorityFilterVariants,
        onAdd: onAddCallback // <- now Add button triggers the callback from Profile
    };
}
