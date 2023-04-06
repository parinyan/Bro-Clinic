new Vue({
    el: "#_invmain",
    data: function () {
        return {
            getinv: [],
            getinvid: [],
            invid: "",
            invrw: "",
            id: "",
            cusid: "",
            rwAr: [],
            fulldetail: [],
            fdetail: [],
            total: 0,
            daterecive: new Date().toISOString().slice(0, 10),
            dataformde: [{
                date: "",
                id: 0

            }],
            idinvoice: 0,
            statusmode: false,
            fulledit: [],
            dateE: [],
            firstnameTH: [],
            lastNameTH: [],
            service: [],
            cusName: [],
            amount: [],
            cusnameE: [],
            Address: [],
            Tax: [],
            com:[]


        }
    }, methods: {

        
        print: function () {

            window.open(window.location.origin + "/invoice/GetPrintinvoice?id=" + this.cusid + "&invoiceid=" + this.invid + "&invrw=" + this.invrw, "'_blank'");

        }, printrec: function () {

            window.open(window.location.origin + "/invoice/GetPrintrec?id=" + this.cusid + "&invoiceid=" + this.invid + "&invrw=" + this.invrw, "'_blank'");

        }
        , changcom() {

            axios.get("/Invoice/Getinvdata", {
                params: {
                    id: this.cusid

                }

            })
                .then(res => {
                    console.log(res.data);

                    this.getinvid = res.data;
                    this.invoiceid = res.data
                    this.invid = res.data[0].invID
                   /* this.txdate = moment(res.data[0].invDate).format('DD/MMM/YYYY')*/
                    this.invrw = res.data[0].rewrite
                  /*  this.nameinvoiceRW = res.data[0].invRewrite*/
                   
                }).catch(err => {
                    console.log(err);
                })

            setTimeout(() =>

                axios.get("/Invoice/GetRewiteinvoice", {
                    params: {
                        id: this.cusid,
                        invoiceid: this.invid,
                        invrw: this.invrw

                    }
                })
                    .then(res => {
                         console.log(res.data)
                        this.rwAr = res.data
                        this.invrw = res.data[0].invrw
                        //this.nameinvoiceRW = res.data[0].invRewrite
                        //this.inrw = res.data[0].inrw
                       

                    })
                    .catch(err => {

                    }), 300);

            setTimeout(() =>

                this.invoicedetail(), 500);

            setTimeout(() =>

                this.invoicedet()


                , 500);
        },
        checkrw: function () {

            axios.get("/Invoice/GetRewiteinvoice", {
                params: {
                    id: this.cusid,
                    invoiceid: this.invid,
                    invrw: this.invrw

                }
            })
                .then(res => {
                    this.rwAr = res.data
                    this.invrw = res.data[0].invrw
                    console.log(this.nameinvoiceRW)

                })
                .catch(err => {

                })


            setTimeout(() =>

                 this.invoicedetail()
                
            
                , 500);
            setTimeout(() =>

                this.invoicedet()


                , 500);


        }, rwchang() {
            this.invoicedetail()
            this.invoicedet()

        },
        invoicedetail: function () {



            axios.get("/Invoice/Getfullinvoice", {
                params: {
                    id: this.cusid,
                    invoiceid: this.invid,
                    inrw: this.invrw

                }
            })
                .then(res => {
                   
                    this.fulldetail = res.data
                    this.idinvoice = res.data[0].idinvoice
                    this.daterecive = res.data[0].daterecep
                  



                })
                .catch(err => {

                    this.address = ""
                    this.tel = ""
                    this.tax = ""
                })

        },
        invoicedet: function () {



            axios.get("/Invoice/Getfulldetailinv", {
                params: {
                    id: this.cusid,
                    invoiceid: this.invid,
                    inrw: this.invrw

                }
            })
                .then(res => {
                   
                    
                    this.fdetail = res.data
                    this.total = 0
                    for (i = 0; i < res.data.length; i++) {
                       
                        this.total += res.data[i].amount
                    }
                    //this.thaibath = ArabicNumberToText(res.data[0].invTotalAmountB);
                    //if (res.data != null) {
                    //    this.address = res.data[0].invAddress
                    //    this.tel = res.data[0].invTel
                    //    this.tax = res.data[0].invTAXID
                    //    this.invd = res.data[0].invDate

                    //    this.totalA = res.data[0].invTotalAmountB.toLocaleString(undefined, { minimumFractionDigits: 2 })
                    //    this.remark = res.data[0].invRemark

                    //    if (res.data[0].invRemark != null && res.data[0].invRemark != "")
                    //        this.remark = res.data[0].invRemark
                    //    else
                    //        this.remark = "Remark...";

                    //    console.log(this.remark)
                    //    const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "June",
                    //        "July", "Aug", "Sep", "Oct", "Nov", "Dec"
                    //    ];
                    //    const current = new Date(res.data[0].invReceiptDate);
                    //    const date = current.getDate() + "/" + (monthNames[current.getMonth()]) + '/' + current.getFullYear();
                    //    const dateTime = date;
                    //    this.invdate = dateTime
                    //    var num = "";
                    //    //if (String(res.data[0].invBillNo).length == 1) {
                    //    //    num = "000"
                    //    //} else if (String(res.data[0].invBillNo).length == 2 ) {
                    //    //    num = "00"
                    //    //} else if (String(res.data[0].invBillNo).length == 3) {
                    //    //    num = "0"
                    //    //}
                    //    this.billno = "RE" + current.getFullYear() + "-0" + res.data[0].invBillNo


                    //} else {
                    //    this.address = ""
                    //    this.tel = ""
                    //    this.tax = ""
                    //}



                })
                .catch(err => {

                    this.address = ""
                    this.tel = ""
                    this.tax = ""
                })

        }, newinv() {

            window.location.href = window.location.origin + "/invoice/InvoiceForm";
        }
        ,
        savedatere() {
            $("#staticBackdrop").show();
            //for (var i = 0; i < this.dataformde.length; i++) {
            //    this.dataformde[i].date = this.date[i];
            //    this.dataformde[i].name = this.Name[i];
            //    this.dataformde[i].namel = this.Namel[i];
            //    this.dataformde[i].Service = this.Service[i];
            //    this.dataformde[i].company = this.Company[i];
            //    this.dataformde[i].Amount = this.Amount[i];
            //    this.dataformde[0].Customer = this.choicecom.id;
            //    this.dataformde[0].Address = this.address;
            //    this.dataformde[0].Tax = this.taxID;
            //    this.dataformde[0].Dateinv = this.Datesel;
            //    this.dataformde[0].number = this.No;

            //}
            this.dataformde[0].date = this.daterecive;
            this.dataformde[0].id = this.idinvoice;
            axios({
                method: 'post',
                url: '/invoice/savedateinv',
                data: this.dataformde
            })
                .then(res => {
                    console.log(res)
                    
                    if (res.data == "suc") {
                        alert("success")
                        $("#staticBackdrop").hide();
                        this.invoicedet()
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })


        }, delper: function (id) {
            alert(id)
            //axios.get("/invoice/edit", {
            //    params: {
            //        id: id
            //    }
            //})
            //    .then(res => {
            //        if (res.data == "success") {
            //            alert("Success")
            //            this.invoicedet()
            //        }

            //    })
            //    .catch(err => {
            //        console.log(err)
            //    })

          

            //console.log(this.fulledit.indexOf(4));

            
            //if (this.fulledit > -1) { // only splice array when item is found
            this.fulledit.splice(id, 1); // 2nd parameter means remove one item only
            this.dateE.splice(id, 1)
            this.firstnameTH.splice(id, 1)
            this.lastNameTH.splice(id, 1)
            this.service.splice(id, 1)
            this.cusName.splice(id, 1)
            this.amount.splice(id, 1)
            //}

            // array = [2, 9]
            console.log(this.fulledit);

        }, editinvoice: function () {

            window.location.href = window.location.origin + "/invoice/editinvoice?id=" + this.cusid + "&invoiceid=" + this.invid + "&inrw=" + this.invrw;
        }, swtmodeopen() {

            this.statusmode = true
            this.fulledit = []
            this.fulldetail = []
            axios.get("/Invoice/Getfulldetailinv", {
                params: {
                    id: this.cusid,
                    invoiceid: this.invid,
                    inrw: this.invrw

                }
            })
                .then(res => {


                    this.fulledit = res.data
                    this.total = 0
                    for (i = 0; i < res.data.length; i++) {

                        this.dateE[i] = res.data[i].dateE
                        this.firstnameTH[i] = res.data[i].firstnameTH
                        this.lastNameTH[i] = res.data[i].lastNameTH
                        this.service[i] = res.data[i].service
                        this.cusName[i] = res.data[i].cusName
                        this.amount[i] = res.data[i].amount

                        this.total += res.data[i].amount
                    }
                   



                })
                .catch(err => {

                    this.address = ""
                    this.tel = ""
                    this.tax = ""
                })

            axios.get("/Invoice/Getfullinvoice", {
                params: {
                    id: this.cusid,
                    invoiceid: this.invid,
                    inrw: this.invrw

                }
            })
                .then(res => {
                    /*  console.log(res.data[0].daterecep)*/
                    console.log(res.data)

                    this.fulldetail = res.data
                    this.idinvoice = res.data[0].idinvoice
                    this.daterecive = res.data[0].daterecep
                    this.Address = res.data[0].address
                    this.Tax = res.data[0].taxID




                })
                .catch(err => {

                    this.address = ""
                    this.tel = ""
                    this.tax = ""
                })
            axios.get("/Invoice/Getcompany")
                .then(res => {
                    /* console.log(res);*/

                    this.com = res.data;
                    console.log(this.com);
                }).catch(err => {
                    console.log(err);
                })
        },
        swtmodeclose() {

            this.statusmode = false
          

        }, addExperience() {
            /* alert("a")*/
            this.fulledit.push({
                dateE: '',
                fnameE: '',
                lnameE: '',
                serE: '',
                ncusE: '',
                amountE: '',
            })
            console.log(this.fulledit)
        }, popExperience() {
            /*alert("a")*/
            if (this.fulledit.length != 1) {
                this.fulledit.pop({
                    dateE: '',
                    fnameE: '',
                    lnameE: '',
                    serE: '',
                    ncusE: '',
                    amountE: '',
                })

            }
            console.log(this.fulledit)
        },
        saveE() {

            $("#staticBackdrop").show();
           
            this.fulledit[0].Address = this.Address;
            this.fulledit[0].Tax = this.Tax;
            this.fulledit[0].invid = this.fulldetail[0].invID;
           /* this.fulledit[0].number = this.fulldetail[0].No;*/
            for (i = 0; i < this.fulledit.length; i++) {

                this.fulledit[i].dateE = this.dateE[i]
                this.fulledit[i].firstnameTH = this.firstnameTH[i]
                this.fulledit[i].lastNameTH = this.lastNameTH[i]
                this.fulledit[i].service = this.service[i]
                this.fulledit[i].cusName = this.cusName[i]
                this.fulledit[i].amount = this.amount[i]

               
            }

            console.log(this.fulledit)
            axios({
                method: 'post',
                url: '/invoice/savedatainvE',
                data: this.fulledit
            })
                .then(res => {
                    /* console.log(res)*/
                    if (res.data == "suc") {
                        alert("success")
                        $("#staticBackdrop").hide();
                       /* this.invoicedet()*/
                        window.location.href = window.location.origin + "/invoice/invoice";
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })



        }
    }, mounted: function () {
        axios.get("/Invoice/Getinv")
            .then(res => {
                console.log(res.data);

                this.getinv = res.data;
                console.log(this.com);
            }).catch(err => {
                console.log(err);
            })

    }


})