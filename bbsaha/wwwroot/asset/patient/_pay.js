new Vue({
    el: "#_pay",
    data: function () {
        return {
            getdatapay: [],
            selepay: "null",
            seleper: "null",
            selemed: "null",
            selerec: "null",
            gettyperev: [],
            gettypepay: [],
            getmedser: [],
            getrec: [],
            startdate: new Date().toISOString().slice(0, 10),
            enddate: new Date().toISOString().slice(0, 10)

        }
    }, methods: {
        getdatapm() {

            axios.get("/Patient/Getdatapm")
                .then(res => {
                     console.log(res.data);
                    this.getdatapay = res.data

                }).catch(err => {
                    console.log(err);
                })


        }, exportex: function () {
            /*alert(this.startdate)*/
            window.open(window.location.origin + "/Patient/Exportex?payty=" + this.selepay + "&perrev=" + this.seleper + "&medser=" + this.selemed + "&startdate=" + this.startdate + "&enddate=" + this.enddate, "'_blank'");

        }
        , searchfil: function () {

            axios.get("/Patient/Getdatapm", {
                params: {
                  
                    payty: this.selepay,
                    perrev: this.seleper,
                    medser: this.selemed,
                    rec: this.selerec,
                    startdate: this.startdate,
                    enddate: this.enddate
                }
            })
                .then(res => {
                    console.log(res.data);
                    this.getdatapay = res.data
                    //this.fulldata = res.data
                    //this.getdatapay.forEach(el => {

                    //   /* this.recea.push(el.transfer)*/
                    //}

                    //)
                    console.log(this.getdatapay)
                })
                .catch(err => {
                    console.log(err)
                })

        }, savedat() {

            const form = new FormData();
           /* form.append('revinvdat', this.getdatapay.revinvdat);*/
            form.append('pricerec', parseFloat(this.getdatapay.pricerec));
            form.append('id', this.getdatapay.id);
           /* form.append('Transfer', this.fulldata.transfer);*/
            //form.append('E_SSO', this.fulldata.e_SSO);
            //form.append('C_SSO', this.fulldata.c_SSO);
            //form.append('id', this.fulldata.invoiceID);
            //form.append('id', this.fulldata.invoiceID);
            ///*   console.log(this.fulldata[1].transfer)*/

            console.log(this.getdatapay)
            var a = this
            $.ajax({
                type: "POST",
                url: "/Patient/Savepayreport",
                data: { "collection": this.getdatapay },
                success: function (result) {

                    
                    if (result == "success") {

                        alert("บันทึกข้อมูลสำเร็จ")
                        a.searchfil()
                    }
                }
            })

        }, gettyperevper() {
            axios.get("/Patient/Getdataret")
                .then(res => {
                    /* console.log(res.data);*/
                    this.gettyperev = res.data

                }).catch(err => {
                    console.log(err);
                })

        }, gettypepayment() {
            axios.get("/Patient/Getdatapayt")
                .then(res => {
                    /* console.log(res.data);*/
                    this.gettypepay = res.data

                }).catch(err => {
                    console.log(err);
                })

        }, gettypemed() {
            axios.get("/Patient/Getdatamedt")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getmedser = res.data

                }).catch(err => {
                    console.log(err);
                })


        }, gettyperec() {
            axios.get("/Patient/Getdatarec")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getrec = res.data

                }).catch(err => {
                    console.log(err);
                })


        },
        printmedreciept(id) {

            /* alert(id)*/
            window.open(window.location.origin + "/Patient/GetPrintreciept?id=" + id, "'_blank'");

        }


    }, mounted:function () {
        //setTimeout(() =>

        //    , 1000);
        this.searchfil()
        this.gettyperevper()
        this.gettypepayment()
        this.gettypemed()
        this.gettyperec()
    }, computed: {
        totalprice() {
            return this.getdatapay.reduce((acc, data) => {

                return acc + parseFloat(data.totalamount)
            }, 0)
        }

    }


})