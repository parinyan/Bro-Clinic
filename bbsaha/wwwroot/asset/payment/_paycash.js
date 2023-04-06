new Vue({
    el: "#_pay",
    data: function () {
        return {
            getdatasummary: [],
            getdatacompany: [],
            getdatacasharr: [],
            savedata: [{
                inpclr: "",
                comment: ""
            }],
            //selepay: "",
            //seleper: "",
            //selemed: "",
            //gettyperev: [],
            //gettypepay: [],
            //getmedser: [],
            //startdate: new Date().toISOString().slice(0, 10),
            //enddate: new Date().toISOString().slice(0, 10) 
            startdate: new Date(new Date().getFullYear(), new Date().getMonth(), 2).toISOString().slice(0, 10),
            enddate: new Date().toISOString().slice(0, 10) ,
            totaccash: 0,
            totascash: 0,
            totacbank: 0,
            totasbank: 0,
            totacinvoice: 0,
            totasinvoice: 0,
            totacper: 0,
            totasper: 0,
            period: 0,
            dateper: [],
           
        }
    }, methods: {
        Getdatasum() {
            axios.get("/Payment/Getdatasum", {
                params: {

                    //payty: this.selepay,
                    //perrev: this.seleper,
                    //medser: this.selemed,
                    startdate: this.startdate,
                    enddate: this.enddate
                }
            })
                .then(res => {
                    /*console.log(res.data);*/
                    this.totaccash = 0
                    this.totascash = 0
                    this.totacbank = 0
                    this.totasbank = 0
                    this.totacinvoice = 0
                    this.totasinvoice = 0
                    this.totacper = 0
                    this.totasper = 0

                    for (var i = 0; i < res.data.length; i++) {
                        this.totaccash += parseInt(res.data[i].ccash)
                        this.totascash += parseInt(res.data[i].scash)
                        this.totacbank += parseInt(res.data[i].cbank)
                        this.totasbank += parseInt(res.data[i].sbank)
                        this.totacinvoice += parseInt(res.data[i].cinvoice)
                        this.totasinvoice += parseInt(res.data[i].sinvoice)
                        this.totacper += parseInt(res.data[i].cper)
                        this.totasper += parseInt(res.data[i].sper)
                        /*  console.log(res.data[i].ccash)*/
                    }

                    this.getdatasummary = res.data
                    //this.fulldata = res.data
                    //this.getdatapay.forEach(el => {

                    //   /* this.recea.push(el.transfer)*/
                    //}

                    //)
                    //console.log(res.data)
                })
                .catch(err => {
                    console.log(err)
                })
            this.Getdatacom()


        }, Getdatacom() {
            axios.get("/Payment/Getdatacom", {
                params: {

                    //payty: this.selepay,
                    //perrev: this.seleper,
                    //medser: this.selemed,
                    startdate: this.startdate,
                    enddate: this.enddate
                }
            })
                .then(res => {
                   


                    this.getdatacompany = res.data
                    //this.fulldata = res.data
                    //this.getdatapay.forEach(el => {

                    //   /* this.recea.push(el.transfer)*/
                    //}

                    //)
                    //console.log(res.data)
                })
                .catch(err => {
                    console.log(err)
                })


        }, check() {
            this.dateper = []
            var date = new Date();
           
            var d1 = new Date(this.startdate)
            var d2 = new Date(this.enddate)

            var f = new Date(this.startdate)

            for (var dt = f; dt <= d2; f.setDate(f.getDate() + 1)) {


                this.dateper.push({ date: dt.getFullYear() + "-" + ("0" + (dt.getMonth() + 1)).slice(-2) + "-" + ("0" + dt.getDate()).slice(-2), sper: "", cper: "" });
              /*  console.log(this.dateper);*/
            }

            const date1 = new Date(d1.getMonth() + "/" + d1.getDate() + "/" + d1.getFullYear());
            const date2 = new Date(d2.getMonth() + "/" + d2.getDate() + "/" + d2.getFullYear());
         /*   console.log(this.startdate)*/

            // One day in milliseconds
            const oneDay = 1000 * 60 * 60 * 24;

            // Calculating the time difference between two dates
            const diffInTime = date2.getTime() - date1.getTime();

            // Calculating the no. of days between two dates
            const diffInDays = Math.round(diffInTime / oneDay);

            this.period = diffInDays
          

            this.Getdatacash()
           /* console.log(firstDay);*/
            //console.log(new Date().toISOString().slice(0, 10));

           

        }, Getdatacash() {
            axios.get("/Payment/Getdatacash", {
                params: {

                    //payty: this.selepay,
                    //perrev: this.seleper,
                    //medser: this.selemed,
                    startdate: this.startdate,
                    enddate: this.enddate
                }
            })
                .then(res => {
                   

                    for (var i = 0; i < res.data.length; i++) {
                        this.dateper[i].sper = (res.data[i].ccash != "" && res.data[i].ccash != null ? parseInt(res.data[i].ccash) : null)
                        this.dateper[i].cper = res.data[i].cper
                       
                    }

                    this.getdatacasharr = res.data
                    //this.fulldata = res.data
                    //this.getdatapay.forEach(el => {

                    //   /* this.recea.push(el.transfer)*/
                    //}

                    //)
                    //console.log(res.data)
                })
                .catch(err => {
                    console.log(err)
                })



        }, savedat() {
          
            
           /* console.log(this.dateper)*/
            var a = this
            $.ajax({
                type: "POST",
                url: "/Payment/Savepayreport",
                data: { "collection": this.dateper },
                success: function (result) {
                    if (result == "success") {

                        alert("บันทึกข้อมูลสำเร็จ")
                        a.check()
                    }
                }
            })

        }, autofildata() {
            

            for (var i = 0; i < this.dateper.length; i++) {
              
                if (this.dateper[i].sper == "" || this.dateper[i].sper == null ) {
                   /* console.log(this.dateper[i].sper)*/
                    //console.log(this.getdatacasharr[i].scash)
                    //if (this.dateper[i].sper != 0) {
                    //    this.dateper[i].cper = "Transfer to Bank"
                    //}
                    this.dateper[i].sper = this.getdatacasharr[i].scash


                } else {

                    this.dateper[i].cper = "Transfer to Bank"
                }
            }
        }
    }, mounted: function () {
        //this.Getdatasum()
        /*this.Getdatacash()*/
        this.check()
    }, computed: {


    }


})