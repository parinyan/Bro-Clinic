Vue.use(VeeValidate);

new Vue({
    el: "#_acc",
    data: function () {
        return {
            username: null,
            password: null,
            confirmpassword: null,
            superuser: false,
            manpower: false,
            timeattendance: false,
            administration: false,
            account: [],
            accs: [],
            users: [],
            accid: [],
            rowPointer: [],
            rowCheck: [],
            suUsered: [],
            ID: [],
            test: [],
            savedcbx: []
           
        }
    },
    computed: {
        isDisabled: function () {
            //alert("aaw");
            console.log(this.account.length);
            if (this.account.length == 0 || this.account.length > 1)
                return true;
            else
                return false;
        },
        isDisableddel: function () {
           
            console.log(this.account.length);
            if (this.account.length == 0)
                return true;
            else
                return false;
        }

    },
     methods: {
       
         refreshData() {
             axios.post("/Account/getdatauser")
                 .then(res => {
                    
                     this.users = res.data

                 })
                 .catch(err => {
                     console.log(err);
                 });
         },
        toggleaccountsave: function () {
            
            const formdata = new FormData();
            formdata.append('Account', this.username);
            formdata.append('Password', this.password);
            formdata.append('confirmpassword', this.confirmpassword);
            formdata.append('SupUser', this.superuser);
            formdata.append('ManPower', this.manpower);
            formdata.append('TimeAttendance', this.timeattendance);
            formdata.append('Administration', this.administration);
            axios.post("/Account/saveuser", formdata)
                .then(res => {
                    this.refreshData();
                    if (res.data == "success") {
                        alert("เพิ่มผู้ใช้งานเรียบร้อยแล้ว")
                        $("#_account_new").modal("hide");
                       
                       
                    }                     
                })
                .catch(err => {
                    console.log(err);
                });
        },
        toggleaccountdetail: function () {

            const formdata = new FormData();
            formdata.append('account', this.account);
            axios.post("/Account/getdataedit", formdata)
                .then(res => {
                    
                    this.accs = res.data

                })
                .catch(err => {
                    console.log(err);
                });

        },
        toggleeditsave: function (accs) {
           
           
            console.log(accs.timeAttendance);
           
            const formdata = new FormData();
            formdata.append('Account', accs.account);
            formdata.append('RowPointer', accs.rowPointer);
            formdata.append('Password', this.password);
            //formdata.append('confirmpassword', this.confirmpassword);
            formdata.append('SupUser', accs.supUser);
            formdata.append('ManPower', accs.manPower);
            formdata.append('TimeAttendance', accs.timeAttendance);
            formdata.append('Administration', accs.administration);
            axios.post("/Account/saveedit", formdata)
                .then(res => {
                    this.refreshData();
                    if (res.data == "success") {
                        alert("แก้ไขผู้ใช้งานเรียบร้อยแล้ว")
                        $("#_account_detail").modal("hide");
                       

                    }

                })
                .catch(err => {
                    console.log(err);
                });

        },
         toggleaccountdelete: function () {
             console.log(this.account);
            
             if (confirm("ต้องการลบผู้ใช้") == true) {
                 const formdata = new FormData();
                 formdata.append('Account', this.account);
                 axios.post("/Account/dataaccountdelete", formdata)
                     .then(res => {
                         this.refreshData();
                         if (res.data == "success") {
                             alert("ลบผู้ใช้งานเรียบร้อยแล้ว")
                             $("#_account_detail").modal("hide");
                             this.account = [];

                         }

                     })
                     .catch(err => {
                         console.log(err);
                     });
             } 
            

         },
        
        
    },
    mounted: function () {
        axios.post("/Account/getdatauser")
            .then(res => {
                console.log(res.data);
                this.users = res.data

            })
            .catch(err => {
                console.log(err);
            });
    },
   
})



//var viewacc = new Vue({

//    el: "#_acc_main",
//    data:  {
//        users: [],
//        account: null,
//        accs: []
//    },
//    mounted: function () {
//        axios.post("/Account/getdatauser")
//            .then(res => {
//                console.log(res.data);
//                this.users = res.data
               
//            })
//            .catch(err => {
//                console.log(err);
//            });
//    }
//})