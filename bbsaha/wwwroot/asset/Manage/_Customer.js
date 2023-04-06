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
            datacom: [],
            users: [],
            accid: [],
            rowPointer: [],
            rowCheck: [],
            suUsered: [],
            ID: [],
            test: [],
            savedcbx: [],
            getcompany: [],
            cusen: [],
            custh: [],
            cusstatus: "1",
            custype: "2",
            cussim: [],
            cusened: [],
            custhed: [],
            cusstatused: "1",
            custypeed: "0",
            cussimed: [],
            cusid: [],
            datatype: []

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
            axios.get("/Manage/getdatacompany")
                .then(res => {
                   /* console.log(res.data);*/
                    this.getcompany = res.data

                })
                .catch(err => {
                    console.log(err);
                });
        },
        togglecussave: function () {

            const formdata = new FormData();
            formdata.append('NameSimple', this.cussim);
            formdata.append('CompanyNameTH', this.custh);
            formdata.append('CompanyNameEN', this.cusen);
            formdata.append('Status', this.cusstatus);
            formdata.append('Type', this.custype);
            //formdata.append('TimeAttendance', this.timeattendance);
            //formdata.append('Administration', this.administration);
            axios.post("/Manage/savecustomer", formdata)
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
        toggledataed: function (id) {

            
            axios.get("/manage/getdataed", {
                params: {
                    id: id

                }

            })
                .then(res => {
                    console.log(res.data)
                    this.datacom = res.data

                    this.cusened = res.data.companyNameEN
                    this.custhed = res.data.companyNameTH
                    this.cusstatused = res.data.status
                    this.custypeed = res.data.type
                    this.cussimed = res.data.nameSimple
                    this.cusid = res.data.id
                    
                })
                .catch(err => {
                    console.log(err);
                });
            this.datatypem()

        },
        togglecusedsave: function (accs) {


           

            const formdata = new FormData();
            formdata.append('NameSimple', this.cussimed);
            formdata.append('CompanyNameTH', this.custhed);
            formdata.append('CompanyNameEN', this.cusened);
            formdata.append('Status', this.cusstatused);
            formdata.append('Type', this.custypeed);
            formdata.append('ID', this.cusid);
            axios.post("/manage/savedataedit", formdata)
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
        togglestatus: function (id,str) {
         

            if (confirm("ต้องการเปิดใช้งาน") == true) {
                const formdata = new FormData();
                formdata.append('ID', id);
                formdata.append('Status', str);
                axios.post("/manage/savedatastatus", formdata)
                    .then(res => {
                        this.refreshData();
                        if (res.data == "success") {
                            alert("เปิดใช้งานเรียบร้อยแล้ว")
                            //$("#_account_detail").modal("hide");
                            //this.account = [];
                            this.refreshData()
                        }

                    })
                    .catch(err => {
                        console.log(err);
                    });
            }


        },
        datatypem: function () {
           
            axios.get("/manage/getdatatypcusmain")
                .then(res => {
                    console.log(res.data)
                    this.datatype = res.data

                })
                .catch(err => {
                    console.log(err);
                });

        }


    },
    mounted: function () {
        axios.post("/Manage/getdatacompany")
            .then(res => {
                console.log(res.data);
                this.getcompany = res.data

            })
            .catch(err => {
                console.log(err);
            });
        this.datatypem()
    }

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