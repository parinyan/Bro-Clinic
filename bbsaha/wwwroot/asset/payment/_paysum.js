new Vue({
    el: "#_pay",
    data: function () {
        return {
            getdatasummary: [],
            getdatacompany: [],
            //selepay: "",
            //seleper: "",
            //selemed: "",
            //gettyperev: [],
            //gettypepay: [],
            //getmedser: [],
            //startdate: new Date().toISOString().slice(0, 10),
            //enddate: new Date().toISOString().slice(0, 10) 
            startdate: null,
            enddate: null,
            totaccash: 0,
            totascash: 0,
            totacbank: 0,
            totasbank: 0,
            totacinvoice: 0,
            totasinvoice: 0,
            totacper: 0,
            totasper: 0,

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
                    console.log(res.data);
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
                    console.log(res.data);

                  
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


        }, searchfill() {


        }, Getdataexport() {

            window.open(window.location.origin + "/Payment/Exportex?startdate=" + this.startdate + "&enddate=" + this.enddate, "'_blank'");
        }

    }, mounted: function () {
        this.Getdatasum() 
        this.Getdatacom()

    }, computed: {
       

    }


})