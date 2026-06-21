document.addEventListener("DOMContentLoaded", () => {
  // Sidebar toggle
  const sidebarToggle = document.getElementById('sidebarToggle');
  const wrapper = document.getElementById('wrapper');
  sidebarToggle.addEventListener('click', () => wrapper.classList.toggle('toggled'));

  // Summary cards
  const summaryCards = [
    { title: 'Total Complaints', count: 124, color: 'bg-primary' },
    { title: 'Resolved', count: 98, color: 'bg-success' },
    { title: 'Pending', count: 22, color: 'bg-warning' },
    { title: 'Rejected', count: 4, color: 'bg-danger' }
  ];
  const cardsContainer = document.getElementById('summary-cards');
  summaryCards.forEach(card => {
    const div = document.createElement('div');
    div.className = 'col-md-3';
    div.innerHTML = `<div class="card text-white ${card.color} shadow-sm"><div class="card-body"><h5 class="card-title">${card.title}</h5><p class="card-text fs-3 fw-bold">${card.count}</p></div></div>`;
    cardsContainer.appendChild(div);
  });

  // Recent complaints
  const recentComplaints = [
    { id: 1, user: 'John Doe', subject: 'Login Issue', date: '2025-08-22', status: 'Pending' },
    { id: 2, user: 'Jane Smith', subject: 'Payment Error', date: '2025-08-21', status: 'Resolved' }
  ];
  const tbody = document.querySelector('#recent-complaints-table tbody');
  recentComplaints.forEach(c => {
    const tr = document.createElement('tr');
    const badge = {
      Pending: 'bg-warning',
      Resolved: 'bg-success',
      Rejected: 'bg-danger'
    };
    tr.innerHTML = `<td>${c.id}</td><td>${c.user}</td><td>${c.subject}</td><td>${c.date}</td><td><span class="badge ${badge[c.status]}">${c.status}</span></td>`;
    tbody.appendChild(tr);
  });

  // Charts
  const ctxLine = document.getElementById('lineChart').getContext('2d');
  new Chart(ctxLine, {
    type: 'line',
    data: {
      labels: ['Jan','Feb','Mar','Apr','May'],
      datasets: [{ label: 'Complaints', data: [12,19,14,22,18], borderColor:'#0d6efd', backgroundColor:'rgba(13,110,253,0.2)', fill:true, tension:0.4 }]
    },
    options: { responsive:true }
  });

  const ctxPie = document.getElementById('pieChart').getContext('2d');
  new Chart(ctxPie, {
    type:'pie',
    data:{ labels:['Resolved','Pending','Rejected'], datasets:[{data:[98,22,4], backgroundColor:['#198754','#ffc107','#dc3545']}] },
    options:{ responsive:true }
  });
});
document.addEventListener("DOMContentLoaded", () => {
  // Sidebar toggle
  const sidebarToggle = document.getElementById('sidebarToggle');
  const wrapper = document.getElementById('wrapper');
  sidebarToggle.addEventListener('click', () => wrapper.classList.toggle('toggled'));

  // Sample complaints data
  const complaints = [
    {id:1, user:'John Doe', subject:'Login Issue', date:'2025-08-22', status:'Pending'},
    {id:2, user:'Jane Smith', subject:'Payment Error', date:'2025-08-21', status:'Resolved'},
    {id:3, user:'Alice Brown', subject:'Profile Update', date:'2025-08-20', status:'Rejected'},
    {id:4, user:'Bob Johnson', subject:'Account Blocked', date:'2025-08-19', status:'Pending'}
  ];

  const tbody = document.querySelector('#complaintsTable tbody');
  const statusFilter = document.getElementById('statusFilter');
  const searchInput = document.getElementById('searchInput');

  function renderTable() {
    const filterStatus = statusFilter.value.toLowerCase();
    const searchText = searchInput.value.toLowerCase();
    tbody.innerHTML = '';

    complaints.filter(c => 
      (filterStatus === '' || c.status.toLowerCase() === filterStatus) &&
      (c.user.toLowerCase().includes(searchText) || c.subject.toLowerCase().includes(searchText))
    ).forEach(c => {
      const badgeClass = c.status === 'Resolved' ? 'bg-success' : c.status === 'Pending' ? 'bg-warning' : 'bg-danger';
      const tr = document.createElement('tr');
      tr.innerHTML = `
        <td>${c.id}</td>
        <td>${c.user}</td>
        <td>${c.subject}</td>
        <td>${c.date}</td>
        <td><span class="badge ${badgeClass}">${c.status}</span></td>
        <td>
          ${c.status === 'Pending' ? `
            <button class="btn btn-success btn-sm me-1" onclick="updateStatus(${c.id}, 'Resolved')">Resolve</button>
            <button class="btn btn-danger btn-sm" onclick="updateStatus(${c.id}, 'Rejected')">Reject</button>
          ` : '-'}
        </td>
      `;
      tbody.appendChild(tr);
    });
  }

  window.updateStatus = function(id, newStatus) {
    const complaint = complaints.find(c => c.id === id);
    if(complaint){
      complaint.status = newStatus;
      renderTable();
    }
  }

  statusFilter.addEventListener('change', renderTable);
  searchInput.addEventListener('input', renderTable);

  renderTable();
});
