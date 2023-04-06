Vue.use(VeeValidate);

new Vue({
    el: "#_acc",
    data: function () {
        return {
            getdataagen: [],
            getdatatype: [],
            //agenname: [],
            //agenstatus: "1",
            //agennameed: [],
            //agenstatused: "1",
            agenid: [],

            typname: [],
            typstatus: [],
            typremark: [],            
            typnameed: [],
            typstatused: [],
            typremarked: [],
            typchklisted: [],
            typchklist: [],
            typid: [],
            getdatatymain: [],
            getdatatypeed: [],
            typpri: [],
            typpried: []




        }
    },
    computed: {

    },
    methods: {

        refreshData() {
            axios.post("/Manage/getdatatypmain")
                .then(res => {
                    console.log(res.data);
                    this.getdatatymain = res.data

                })
                .catch(err => {
                    console.log(err);
                });
        },
        toggletypsave: function () {

            const formdata = new FormData();
            formdata.append('TypeName', this.typname);
            formdata.append('Remark', this.typremark);
            formdata.append('Price', this.typpri);
            formdata.append('Status', this.typstatus);
            this.typchklist.forEach((obj, index) => {
                formdata.append(`list[${index}]`, obj);
            });
            /*  formdata.append('Type', this.custype);*/
            //formdata.append('TimeAttendance', this.timeattendance);
            //formdata.append('Administration', this.administration);


            axios.post("/Manage/savetyp", formdata)
                .then(res => {
                    this.refreshData();
                    if (res.data == "success") {
                        alert("Success")
                        $("#_account_new").modal("hide");

                        this.typchklist = []
                    }
                })
                .catch(err => {
                    console.log(err);
                });

           /* console.log(this.typchklist)*/
        },
        toggledataed: function (id) {


            axios.get("/manage/getdatatyped", {
                params: {
                    id: id

                }

            })
                .then(res => {
                    console.log(this.typchklisted)
                    this.typchklisted = []

                    this.typnameed = res.data[0].x.typeName
                    this.typremarked = res.data[0].x.remark
                    this.typstatused = res.data[0].x.status
                    this.typpried = res.data[0].x.price
                    this.agenid = res.data[0].x.id

                    for (var i = 0; i < res.data.length; i++) {
                        this.typchklisted.push(res.data[i].y.detailID)

                    }
                    console.log(this.typchklisted)
                })
                .catch(err => {
                    console.log(err);
                });

        },
        toggletypedsave: function () {


            /*console.log(this.typchklisted)*/

            const formdata = new FormData();
            formdata.append('TypeName', this.typnameed);
            formdata.append('Remark', this.typremarked);
            formdata.append('Price', this.typpried);
            formdata.append('Status', this.typstatused);
            formdata.append('ID', this.agenid);
            this.typchklisted.forEach((obj, index) => {
                formdata.append(`list[${index}]`, obj);
            });
            axios.post("/manage/savedatatypedit", formdata)
                .then(res => {
                    this.refreshData();
                    if (res.data == "success") {
                        alert("Success")
                        $("#_account_detail").modal("hide");
                        this.typchklisted = []

                    }

                })
                .catch(err => {
                    console.log(err);
                });

        },
        togglestatus: function (id, str) {


            if (confirm("ต้องการเปิดใช้งาน") == true) {
                const formdata = new FormData();
                formdata.append('ID', id);
                formdata.append('Status', str);
                axios.post("/manage/savedatatypestatus", formdata)
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
        console.log(this.typchklisted)
        axios.post("/Manage/getdatatypmain")
            .then(res => {
                console.log(res.data);
                this.getdatatymain = res.data

            })
            .catch(err => {
                console.log(err);
            });

        axios.post("/Manage/getdatatyp")
            .then(res => {
                console.log(res.data);
                this.getdatatype = res.data
                this.getdatatypeed = res.data
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