Vue.use(VeeValidate);

new Vue({
    el: "#_acc",
    data: function () {
        return {
           getdataagen: [],
            agenname: [],
            agenstatus: "1",
            agennameed: [],
            agenstatused: "1",
            agenid: []

        }
    },
    computed: {
       
    },
    methods: {

        refreshData() {
            axios.get("/Manage/getdataagency")
                .then(res => {
                    console.log(res.data);
                    this.getdataagen = res.data

                })
                .catch(err => {
                    console.log(err);
                });
        },
        toggleagensave: function () {

            const formdata = new FormData();
            formdata.append('AgenName', this.agenname);
            formdata.append('Status', this.agenstatus);
          /*  formdata.append('Type', this.custype);*/
            //formdata.append('TimeAttendance', this.timeattendance);
            //formdata.append('Administration', this.administration);
            axios.post("/Manage/saveagency", formdata)
                .then(res => {
                    this.refreshData();
                    if (res.data == "success") {
                        alert("เพิ่มผู้แนะนำเรียบร้อยแล้ว")
                        $("#_account_new").modal("hide");


                    }
                })
                .catch(err => {
                    console.log(err);
                });
        },
        toggledataed: function (id) {


            axios.get("/manage/getdataagened", {
                params: {
                    id: id

                }

            })
                .then(res => {
                    console.log(res.data)
                

                    this.agennameed = res.data.agenName
                    this.agenstatused = res.data.status
                    this.agenid = id
                })
                .catch(err => {
                    console.log(err);
                });

        },
        toggleagenedsave: function () {




            const formdata = new FormData();
            formdata.append('AgenName', this.agennameed);
            formdata.append('Status', this.agenstatused);
            formdata.append('ID', this.agenid);
            axios.post("/manage/savedataagenedit", formdata)
                .then(res => {
                    this.refreshData();
                    if (res.data == "success") {
                        alert("แก้ไขผู้แนะนำเรียบร้อยแล้ว")
                        $("#_account_detail").modal("hide");


                    }

                })
                .catch(err => {
                    console.log(err);
                });

        },
        toggleagenstatus: function (id, str) {


            if (confirm("ต้องการเปิดใช้งาน") == true) {
                const formdata = new FormData();
                formdata.append('ID', id);
                formdata.append('Status', str);
                axios.post("/manage/savedataagenstatus", formdata)
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


    },
    mounted: function () {
        axios.post("/Manage/getdataagency")
            .then(res => {
                console.log(res.data);
                this.getdataagen = res.data

            })
            .catch(err => {
                console.log(err);
            });
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