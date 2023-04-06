new Vue({
    el: '#_inv_summa',
    data: function () {
        return {
            year: [],
            com: [],
            seleyear: null,
            selecom: null,
            selemon: null,
            seletype: null,
            fulldata: [],
            transfersum: [],
            inv: [],
            recea: []
        }

    },
    mounted: function () {
        axios.get("/invoice/Getyearsummary")
            .then(res => {
                //console.log(res.data)
                this.year = res.data
                this.seleyear = res.data[0].year


            })
            .catch(err => {


            })

        axios.get("/invoice/Getcomsummary")
            .then(res => {
                //console.log(res.data)
                this.com = res.data

            })
            .catch(err => {


            })
        setTimeout(() =>

            this.searchfil(), 1000);


    }
    ,
    methods: {
        searchfil: function () {
           
            axios.get("/invoice/Getsummamry", {
                params: {
                    year: this.seleyear,
                    company: this.selecom,
                    month: this.selemon,
                    type: this.seletype
                }
            })
                .then(res => {

                    this.fulldata = res.data
                    this.fulldata.forEach(el => {

                        this.recea.push(el.transfer)
                    }

                    )
                    console.log(res.data)
                })
                .catch(err => {
                    console.log(err)
                })

        },
        app: function (id) {
            axios.get("/invoice/Approve", {
                params: {
                    id: id
                }
            })
                .then(res => {
                    if (res.data == "success") {
                        alert("Approve Success")
                        this.searchfil()
                    }

                })
                .catch(err => {
                    console.log(err)
                })

        },
        notapp: function (id) {
            axios.get("/invoice/NotApprove", {
                params: {
                    id: id
                }
            })
                .then(res => {
                    if (res.data == "success") {
                        alert("NotApprove Success")
                        this.searchfil()
                    }

                })
                .catch(err => {
                    console.log(err)
                })

        },
        savedat: function () {
            const form = new FormData();
            form.append('Customer', this.fulldata.customer);
            form.append('InvoiceID', this.fulldata.invoiceID);
            form.append('Transfer', this.fulldata.transfer);
            //form.append('E_SSO', this.fulldata.e_SSO);
            //form.append('C_SSO', this.fulldata.c_SSO);
            //form.append('id', this.fulldata.invoiceID);
            //form.append('id', this.fulldata.invoiceID);
            ///*   console.log(this.fulldata[1].transfer)*/

            //console.log(this.recea)
            var a = this
            $.ajax({
                type: "POST",
                url: "/invoice/Savesummary",
                data: { "collection": this.fulldata },
                success: function (result) {
                    if (result == "success") {

                        alert("บันทึกข้อมูลสำเร็จ")
                        a.searchfil()
                    }
                }
            })

            //console.log(this.fulldata)
            //axios.post("/invoice/Savesummary", { "collection": this.fulldata })
            //    .then(res => {
            //        console.log(res.data)
            //        if (res.data == "success") {
            //            alert("NotApprove Success")
            //            /*this.searchfil()*/
            //        }

            //    })
            //    .catch(err => {
            //        console.log(err)
            //    })

        },
        customFormatter(date) {

            return moment(date).format('DD/MMM/yyyy');
        }, printinvoice: function (cusid, nameid, InvRewrite) {

            window.open(window.location.origin + "/invoice/GetPrintinvoice?id=" + cusid + "&invoiceid=" + nameid + "&invrw=" + InvRewrite, "'_blank'");
        }, printreceive: function (cusid, nameid, InvRewrite) {

            window.open(window.location.origin + "/invoice/GetPrintrec?id=" + cusid + "&invoiceid=" + nameid + "&invrw=" + InvRewrite, "'_blank'");
        }, exportex: function () {

            window.open(window.location.origin + "/invoice/Exportex?year=" + this.seleyear + "&company=" + this.selecom + "&month=" + this.selemon + "&type=" + this.seletype, "'_blank'");

        }, delinv: function (id) {
            if (confirm("you want delete invoice ?") == true) {
                axios.get("/invoice/delinvoice", {
                    params: {
                        id: id
                    }
                })
                    .then(res => {
                        if (res.data == "success") {
                            alert("delete Success")
                            this.searchfil()
                        }

                    })
                    .catch(err => {
                        console.log(err)
                    })
            } else {


            }
        }
    }, computed: {
        totalsalary() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.salary.replace(/,/g, ''))
            }, 0)
        }, totalot() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.ot.replace(/,/g, ''))
            }, 0)
        }, totalwelfare() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.welfare.replace(/,/g, ''))
            }, 0)
        }, totalcharge() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.charge.replace(/,/g, ''))
            }, 0)
        }, totalinvoice() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.total.replace(/,/g, ''))
            }, 0)
        }, totalvat() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.vat.replace(/,/g, ''))
            }, 0)
        }, totalwht() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.withhold.replace(/,/g, ''))
            }, 0)
        }
        , totaltransfersa() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.transfer.replace(/,/g, ''))
            }, 0)
        }, totalReceive() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.receive.replace(/,/g, ''))
            }, 0)
        }, totalsso() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.sso.replace(/,/g, ''))
            }, 0)
        }, totalesso() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.e_SSO.replace(/,/g, ''))
            }, 0)
        }, totalcsso() {
            return this.fulldata.reduce((acc, data) => {


                return acc + parseFloat(data.c_SSO.replace(/,/g, ''))
            }, 0)
        }
    },
    components: {
        vuejsDatepicker
    }

})