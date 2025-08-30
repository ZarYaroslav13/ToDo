import {
    Box, Paper, Toolbar, Typography, TextField, Button,
    Table, TableBody, TableCell, TableContainer, TableHead,
    TablePagination, TableRow, TableSortLabel, IconButton, Tooltip
} from "@mui/material";
import { Delete, Edit, Add } from "@mui/icons-material";
import { visuallyHidden } from "@mui/utils";
import { useTasksViewModel } from "./tasktableViewModule";

export default function TasksTable({ tasks, onDelete, onEdit, onAdd }) {
    const vm = useTasksViewModel(tasks);

    return (
        <Box sx={{ width: "100%" }}>
            <Paper sx={{ width: "100%", mb: 2, p: 2 }}>
                <Toolbar>
                    <Typography variant="h6" sx={{ flex: "1 1 100%" }}>
                        Tasks
                    </Typography>
                    <TextField
                        size="small"
                        placeholder="Filter by title..."
                        value={vm.filter}
                        onChange={(e) => vm.setFilter(e.target.value)}
                        sx={{ mr: 2 }}
                    />
                    <Button variant="contained" startIcon={<Add />} onClick={onAdd}>
                        Add Task
                    </Button>
                </Toolbar>

                <TableContainer>
                    <Table>
                        <TableHead>
                            <TableRow>
                                {["title", "priority", "deadline", "description"].map((col) => (
                                    <TableCell key={col} sortDirection={vm.orderBy === col ? vm.order : false}>
                                        <TableSortLabel
                                            active={vm.orderBy === col}
                                            direction={vm.orderBy === col ? vm.order : "asc"}
                                            onClick={() => vm.handleRequestSort(null, col)}
                                        >
                                            {col}
                                            {vm.orderBy === col && (
                                                <Box component="span" sx={visuallyHidden}>
                                                    {vm.order === "desc" ? "sorted descending" : "sorted ascending"}
                                                </Box>
                                            )}
                                        </TableSortLabel>
                                    </TableCell>
                                ))}
                                <TableCell>Actions</TableCell>
                            </TableRow>
                        </TableHead>

                        <TableBody>
                            {vm.visibleRows.map((task) => (
                                <TableRow key={task.Id}>
                                    <TableCell>{task.title}</TableCell>
                                    <TableCell>{task.priority}</TableCell>
                                    <TableCell>{task.deadline}</TableCell>
                                    <TableCell>{task.description}</TableCell>
                                    <TableCell>
                                        <Tooltip title="Edit">
                                            <IconButton onClick={() => onEdit(task)}>
                                                <Edit />
                                            </IconButton>
                                        </Tooltip>
                                        <Tooltip title="Delete">
                                            <IconButton onClick={() => onDelete(task.Id)}>
                                                <Delete />
                                            </IconButton>
                                        </Tooltip>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>

                <TablePagination
                    rowsPerPageOptions={[5, 10, 25]}
                    component="div"
                    count={vm.filteredTasks.length}
                    rowsPerPage={vm.rowsPerPage}
                    page={vm.page}
                    onPageChange={vm.handleChangePage}
                    onRowsPerPageChange={vm.handleChangeRowsPerPage}
                />
            </Paper>
        </Box>
    );
}
