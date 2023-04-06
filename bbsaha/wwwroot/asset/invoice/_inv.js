new Vue({
    el: "#_cardform",
    data: function () {
        return {
            dataformde: [],
            date: [],
            Name: [],
            Namel: [],
            Service: [],
            Company: [],
            Amount: [],
            com: [],
            choicecom: {
                id: 0,
                idcode:0

            },
            address: [],
            taxID: [],
            Datesel: new Date().toISOString().slice(0, 10),
            No: "",
            datasave: [],
           
            
        }

    }, methods: {
        addExperience() {
            /* alert("a")*/
            this.dataformde.push({
                Name: '',
                Namel: '',
                Service: '',
                Company: '',
                Amount: '',
            })
        }, popExperience() {
            /*alert("a")*/
            if (this.dataformde.length != 1) {
                this.dataformde.pop({
                    Name: '',
                    Namel: '',
                    Service: '',
                    Company: '',
                    Amount: '',
                })

            }
        }, saveexp() {
            $("#staticBackdrop").show();
            for (var i = 0; i < this.dataformde.length; i++) {
                this.dataformde[i].date = this.date[i];
                this.dataformde[i].name = this.Name[i];
                this.dataformde[i].namel = this.Namel[i];
                this.dataformde[i].Service = this.Service[i];
                this.dataformde[i].company = this.Company[i];
                this.dataformde[i].Amount = this.Amount[i];
                this.dataformde[0].Customer = this.choicecom.id;
                this.dataformde[0].Address = this.address;
                this.dataformde[0].Tax = this.taxID;
                this.dataformde[0].Dateinv = this.Datesel;
                this.dataformde[0].number = this.No;

            }

            axios({
                method: 'post',
                url: '/invoice/savedatainv',
                data: this.dataformde
            })
                .then(res => {
                   /* console.log(res)*/
                    if (res.data == "suc") {
                        alert("success")
                        $("#staticBackdrop").hide();
                        window.location.href = window.location.origin + "/invoice/invoice";
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        },
        
        togglecom: function () {

            axios.get("/Invoice/Getinvoiceid", {
                params: {
                    id: this.choicecom.id,
                    InvDate: this.Datesel,
                    idcode: this.choicecom.idcode
                }
            })
                .then(res => {
                    if (res.data != null) {
                        this.No = res.data;
                        /*this.No = $('#invdate').val()*/

                    } else {
                        this.No = "";

                    }
                   /* console.log(this.forminvoice.InvInvoiceID);*/
                })
                .catch(err => {
                    console.log(err);
                })

            axios.get("/Invoice/Getcompany_detail", {
                params: {
                    id: this.choicecom.id

                }
            })
                .then(res => {
                    if (res.data != null) {
                        this.address = res.data.address;
                        /*this.forminvoice.InvTel = res.data.invTel;*/
                        this.taxID = res.data.taxID;
                        /*this.forminvoice.InvCustID = this.choicecom;*/
                    } else {
                        this.address = "";
                        /*this.forminvoice.InvTel = "";*/
                        this.taxID = "";
                       /* this.forminvoice.InvCustID = this.choicecom;*/
                    }
                    console.log(this.forminvoice.InvCustID);
                    console.log(this.forminvoice.InvDate);
                })
                .catch(err => {
                    console.log(err);
                })

        },
        currentDateTime() {
            const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "June",
                "July", "Aug", "Sep", "Oct", "Nov", "Dec"
            ];
            const current = new Date();
            const date = current.getDate() + "/" + (monthNames[current.getMonth()]) + '/' + current.getFullYear();

            const dateTime = date;

            return dateTime;
        }
    }, mounted: function(){


       
            this.dataformde.push({
                Name: '',
                Namel: '',
                Service: '',
                Company: '',
                Amount: '',
            })
        axios.get("/Invoice/Getcompany")
            .then(res => {
                /* console.log(res);*/

                this.com = res.data;
                console.log(this.com);
            }).catch(err => {
                console.log(err);
            })
        /*this.Datesel = this.currentDateTime();*/
    }

})