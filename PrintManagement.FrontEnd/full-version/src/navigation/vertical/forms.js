export default [
  { title: "Quản lý nhân viên", to: "tables-simple-table" },
  // { title: "Quản lý kho", to: "tables-warehouse" },
  {
    title: "Quản lý khách hàng",
    to: "tables-data-table",
    meta: {
      auth: ["Admin"],
    },
  },
];
