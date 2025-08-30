import { useState, useMemo } from "react";
import { Priority } from "../../enums/priority";

function descendingComparator(a, b, orderBy) {
    if (b[orderBy] < a[orderBy]) return -1;
    if (b[orderBy] > a[orderBy]) return 1;
    return 0;
}

function getComparator(order, orderBy) {
    return order === "desc"
        ? (a, b) => descendingComparator(a, b, orderBy)
        : (a, b) => -descendingComparator(a, b, orderBy);
}

export function useTasksViewModel(tasks) {
    const [order, setOrder] = useState("asc");
    const [orderBy, setOrderBy] = useState("title");
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);
    const [filter, setFilter] = useState("");
    const [priorityFilter, setPriorityFilter] = useState([]);

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
            return matchesTitle && matchesPriority;
        });
    }, [tasks, filter, priorityFilter]);

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
        handleRequestSort,
        handleChangePage,
        handleChangeRowsPerPage,
        filteredTasks,
        visibleRows,
        PriorityFilterVariants
    };
}
