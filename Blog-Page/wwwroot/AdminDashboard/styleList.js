const data = [
    { id: 1, name: 'Item 1', status: 'Pending' },
    { id: 2, name: 'Item 2', status: 'Approved' },
    { id: 3, name: 'Item 3', status: 'Rejected' },
    // Add more data as needed
];

let sortField = 'id'; // Default sort field
let sortDirection = 'asc'; // Default sort directiona

const tableBody = document.getElementById('tableBody');
const tableHeader = document.querySelector('#dataTable thead');
const darkModeToggle = document.getElementById('darkModeToggle');
const darkModeClass = 'dark';

// Helper function to render the table
function renderTable() {
    tableBody.innerHTML = '';
    data
        .sort((a, b) => {
            const aValue = a[sortField];
            const bValue = b[sortField];
            if (typeof aValue === 'string') {
                return sortDirection === 'asc'
                    ? aValue.localeCompare(bValue)
                    : bValue.localeCompare(aValue);
            } else if (typeof aValue === 'number') {
                return sortDirection === 'asc' ? aValue - bValue : bValue - aValue;
            } else {
                return 0;
            }
        })
        .forEach(item => {
            const row = document.createElement('tr');
            row.innerHTML = `
        <td class="border px-4 py-2">${item.id}</td>
        <td class="border px-4 py-2">${item.name}</td>
        <td class="border px-4 py-2">
          <span class="pill ${item.status === 'Pending' ? 'bg-yellow-200 text-yellow-800' : item.status === 'Approved' ? 'bg-green-200 text-green-800' : 'bg-red-200 text-red-800'}">${item.status}</span>
        </td>
        <td class="border px-4 py-2">
          <button class="btn btn-edit">Edit</button>
          <button class="btn btn-delete">Delete</button>
          <button class="btn btn-update">Update</button>
        </td>
      `;
            tableBody.appendChild(row);
        });

}

// Dark mode toggle
darkModeToggle.addEventListener('change', () => {
    document.body.classList.toggle(darkModeClass);
    tableHeader.classList.toggle('table-dark');
    renderTable(); // Rerender table to update pill colors
});

// Table header click event for sorting
tableHeader.addEventListener('click', e => {
    if (e.target.tagName === 'TH') {
        const clickedField = e.target.dataset.field;
        if (clickedField) {
            if (clickedField === sortField) {
                sortDirection = sortDirection === 'asc' ? 'desc' : 'asc';
            } else {
                sortField = clickedField;
                sortDirection = 'asc';
            }
            renderTable();
        }
    }
});

// Initial rendering
renderTable();
