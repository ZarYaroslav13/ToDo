import { useState, useMemo } from "react";

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

  const handleRequestSort = (_, property) => {
    const isAsc = orderBy === property && order === "asc";
    setOrder(isAsc ? "desc" : "asc");
    setOrderBy(property);
  };

  const handleChangePage = (_, newPage) => setPage(newPage);
  const handleChangeRowsPerPage = (e) => {
    setRowsPerPage(parseInt(e.target.value, 10));
    setPage(0);
  };

  const filteredTasks = useMemo(
    () => tasks.filter((t) =>
      t.title?.toLowerCase().includes(filter.toLowerCase())
    ),
    [tasks, filter]
  );

  const visibleRows = useMemo(
    () =>
      [...filteredTasks]
        .sort(getComparator(order, orderBy))
        .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage),
    [filteredTasks, order, orderBy, page, rowsPerPage]
  );

  return {
    order, orderBy, page, rowsPerPage, filter,
    setFilter, handleRequestSort, handleChangePage, handleChangeRowsPerPage,
    filteredTasks, visibleRows
  };
}
