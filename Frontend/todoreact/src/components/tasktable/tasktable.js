import React from "react";
import {
    Table, TableBody, TableCell, TableContainer,
    TableHead, TableRow, TablePagination, TableSortLabel,
    TextField, Paper, FormControl, InputLabel, Select, MenuItem, OutlinedInput, Box, Chip
} from "@mui/material";
import { useTasksViewModel } from "./tasktableViewModule";

const columns = [
    { id: "title", label: "Title" },
    { id: "priority", label: "Priority" },
    { id: "deadline", label: "Deadline" },
    { id: "description", label: "Description" },
];

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
    PaperProps: {
        style: {
            maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
            width: 250,
        },
    },
};

export function TasksTable({ tasks }) {
    const vm = useTasksViewModel(tasks);

    const handlePriorityChange = (event) => {
        const {
            target: { value },
        } = event;
        vm.setPriorityFilter(typeof value === "string" ? value.split(",") : value);
    };

    return (
        <Paper sx={{ width: "100%", overflow: "hidden" }}>

            <div style={{ display: "flex", gap: "1rem", padding: "1rem" }}>
                <TextField
                    label="Search by Title"
                    value={vm.filter}
                    onChange={(e) => vm.setFilter(e.target.value)}
                    size="small"
                />
                <FormControl sx={{ minWidth: 200 }} size="small">
                    <InputLabel>Priority</InputLabel>
                    <Select
                        multiple
                        value={vm.priorityFilter}
                        onChange={handlePriorityChange}
                        input={<OutlinedInput label="Priority" />}
                        renderValue={(selected) => (
                            <Box sx={{ display: "flex", flexWrap: "wrap", gap: 0.5 }}>
                                {selected.map((value) => (
                                    <Chip key={value} label={value} />
                                ))}
                            </Box>
                        )}
                        MenuProps={MenuProps}
                    >
                        {Object.values(vm.PriorityFilterVariants).map((priority) => (
                            <MenuItem key={priority} value={priority}>
                                {priority}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>

                <TextField
                    label="Start Date"
                    type="date"
                    size="small"
                    value={vm.startDate}
                    onChange={(e) => vm.setStartDate(e.target.value)}
                    InputLabelProps={{ shrink: true }}
                />
                <TextField
                    label="End Date"
                    type="date"
                    size="small"
                    value={vm.endDate}
                    onChange={(e) => vm.setEndDate(e.target.value)}
                    InputLabelProps={{ shrink: true }}
                />
            </div>


            <TableContainer>
                <Table stickyHeader>
                    <TableHead>
                        <TableRow>
                            {columns.map((col) => (
                                <TableCell
                                    key={col.id}
                                    sortDirection={vm.orderBy === col.id ? vm.order : false}
                                >
                                    <TableSortLabel
                                        active={vm.orderBy === col.id}
                                        direction={vm.orderBy === col.id ? vm.order : "asc"}
                                        onClick={(e) => vm.handleRequestSort(e, col.id)}
                                    >
                                        {col.label}
                                    </TableSortLabel>
                                </TableCell>
                            ))}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {vm.visibleRows.length === 0 ? (
                            <TableRow>
                                <TableCell colSpan={columns.length} align="center">
                                    No tasks found
                                </TableCell>
                            </TableRow>
                        ) : (
                            vm.visibleRows.map((task) => (
                                <TableRow hover key={task.id}>
                                    <TableCell>{task.title}</TableCell>
                                    <TableCell>{task.priority.name}</TableCell>
                                    <TableCell>
                                        {task.deadline
                                            ? new Date(task.deadline).toLocaleDateString()
                                            : "—"}
                                    </TableCell>
                                    <TableCell>{task.description}</TableCell>
                                </TableRow>
                            ))
                        )}
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
    );
}
