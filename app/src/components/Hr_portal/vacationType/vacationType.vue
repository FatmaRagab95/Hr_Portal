<template>
  <div class="Courses internal-page" id="Vacation_type">
    <h1>
      <img src="../../../assets/layout/img/course.png" alt="courses" />
      Vacation Types
    </h1>

    <div class="custom-form create-course">
      <div class="cu-container">
        <div class="cu-form-group special p-4">
          <div class="title">
            <span>Vacation Type</span>
          </div>

          <div class="grouped shadow-sm pt-4 rounded">
            <div class="row">
              <!-- vacation type -->
              <div class="col-md-6">
                <div class="cu-field">
                  <label class="cu-label">
                    <span>Add New Vacation Type:</span>
                  </label>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <input type="text" v-model="NewHR_Vacation_Type.Type_Name" />
                  </div>
                </div>
              </div>

              <!-- vacation id -->
              <div class="col-md-6">
                <div class="cu-field">
                  <label class="cu-label">
                    <span>Add New Vacation Id:</span>
                  </label>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <input type="number" v-model="NewHR_Vacation_Type.id" />
                  </div>
                </div>
              </div>
            </div>
            <!-- submit-->
            <div class="text-center">
              <button
                class="special-btn"
                type="button"
                v-on:click.prevent="SubmitVacationType"
              >
                Add
              </button>
            </div>
          </div>

          <div class="grouped shadow-sm pt-4 pb-5 rounded">
            <div class="row">
              <!-- vacation type -->
              <div class="col-md-12">
                <div class="cu-field">
                  <label class="cu-label">
                    <span>All Vacation Types:</span>
                  </label>

                  <table class="table table-striped text-center">
                    <thead class="bg-secondary text-white">
                      <tr>
                        <th scope="col" class="">#</th>
                        <th scope="col">Vacation Type</th>
                        <th scope="col">Vacation Id</th>
                        <th scope="col">delete</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr v-for="(type, i) in Vacations" :key="type.id">
                        <th>{{ i + 1 }}</th>
                        <th>{{ type.Type_Name }}</th>
                        <th>{{ type.id }}</th>
                        <th>
                          <a href="#">
                            <i
                              class="fa fa-trash fa-lg btn text-danger"
                              aria-hidden="true"
                              @click.prevent="deleteVacation(type.id, true)"
                            >
                            </i>
                          </a>
                        </th>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "workRequest",
  data() {
    return {
      //user: JSON.parse(localStorage.getItem("user")),
      Vacations: null,

      NewHR_Vacation_Type: {
        Type_Name: "",
        id: 0,
      },

      apiUrl: "http://localhost:56438/app/dist/",
    };
  },

  methods: {
    SubmitVacationType: function () {
      let that = this,
        ObjectD = Object.assign({}, this.NewHR_Vacation_Type);

      if (ObjectD.Type_Name == "") {
        swal({
          title: "Error!",
          text: "Sorry you should type the vacation type ! ",
          icon: "warning",
          dangerMode: true,
        });
      } else {
        //ObjectD['Type_Name'] = this.types.filter(x => x['id'] == ObjectD['Type_Name'])[0].Type_Name;
        //ObjectD["Type_Id"] = parseInt(ObjectD["id"]);

        $.ajax({
          type: "POST",
          url: that.apiUrl + "Hr_Portal/Vacation_type.aspx/NewHR_Vacation_Type",
          data: JSON.stringify({ Vacation_Type: ObjectD }),
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function () {
            swal({
              title: "Good job!",
              text: "You successfully added vacation type ...",
              icon: "success",
            }).then((result) => {
              if (result) {
                //window.location = "Vacation_type.aspx";
                Location.reload();
              } else {
                swal({
                  title: "Canceled",
                  text: "Sorry, you can not add vacation type !",
                });
              }
            });
          },
        });
      }
    },

    deleteVacation: function (id, hide) {
      let cobject = this;
      $.ajax({
        type: "POST",
        url: cobject.apiUrl + "Hr_Portal/Vacation_type.aspx/updateHide",
        data: JSON.stringify({ detail: { id: id, Hide: hide } }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
          swal({
            title: "Success!",
            text: "You successfully cleared the vacation type ...",
            icon: "success",
          }).then((result) => {
            if (result) {
              //window.location = "Vacation_type.aspx";
              location.reload();
            } else {
              swal({
                title: "Canceled",
                text: "Sorry, you can not delete the vacation type !",
              });
            }
          });
        },
      });
    },
  },

  created: function () {
    let cobject = this;

    //get Vacation types
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Vacation_type.aspx/gettypesData",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.types = JSON.parse(data.d);
        cobject.Vacations = cobject.types.filter((x) => x.Hide == false);
      },
    });
  },
};
</script>

<style></style>
