<template>
  <div class="Courses internal-page" id="employee_balance">
    <h1>
      <img src="../../../assets/layout/img/course.png" alt="courses" />
      Employee Balance
    </h1>

    <form>
      <div class="custom-form create-course">
        <div class="cu-container">
          <div class="cu-form-group special p-4">
            <div class="title">
              <span>Employee Balance</span>
            </div>

            <div class="grouped shadow-sm rounded">
              <div class="row">
                <!-- employee id -->
                <div class="cu-field col-md-12">
                  <h3 class="cu-label">
                    <label>Employee Id :</label>
                  </h3>
                  <div class="cu-input text-box" style="max-width: 100%">
                    <span class="fa fa-edit"></span>
                    <input v-model="impId" v-on:keydown.enter.prevent />
                  </div>
                </div>
                <!-- employee name -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Employee Name :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ impName }}</div>
                  </div>
                </div>
                <!-- employee jop discription -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Employee Jop Description :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ impDisc }}</div>
                  </div>
                </div>
                <!-- employee department -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Employee Department :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ impDept }}</div>
                  </div>
                </div>
                <!-- employee branch -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Employee Branch :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ impBranch }}</div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Employee balance -->
            <div class="grouped shadow-sm rounded mb-4" id="insert-balance">
              <div class="row">
                <!-- set balance -->
                <div class="cu-field col-md-12">
                  <h3 class="cu-label">
                    <label>Employee Total Balance :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <select id="projects" class="form-control" v-model="empBalance">
                      <option value="0" selected="selected">..</option>
                      <option>{{ fewBalance }} days</option>
                      <option>{{ larageBalance }} days</option>
                      <option>other...</option>
                    </select>
                  </div>
                </div>
                <!-- set new balance -->
                <div
                  class="cu-field col-md-12"
                  id="newBalance"
                  v-if="empBalance == 'other...'"
                >
                  <h3 class="cu-label">
                    <label>Set Employee Total New Balance :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      v-model="newBalance"
                      v-on:keydown.enter.prevent
                    />
                  </div>
                </div>
                <!-- Quqrter One -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter One :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q1_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box" id="q1" v-if="empBalance != 'other...'">
                    <span class="fa fa-edit"></span>
                    <div>{{ quarterOne }} days</div>
                  </div>
                  <div
                    class="cu-input text-box mt-3 mb-3"
                    id="q1input"
                    v-if="empBalance == 'other...'"
                  >
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="newBalance > 21 ? 7 : newBalance <= 5 ? newBalance : 5"
                      v-model="quarterOne"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{ newBalance > 21 ? 7 : (newBalance) => (5 ? newBalance : 5) }}
                    </span>
                  </div>
                </div>
                <!-- Quqrter Two -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Two :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q2_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box" id="q2" v-if="empBalance != 'other...'">
                    <span class="fa fa-edit"></span>
                    <div>{{ quarterTwo }} days</div>
                  </div>
                  <div
                    class="cu-input text-box mt-3 mb-3"
                    id="q2input"
                    v-if="empBalance == 'other...'"
                  >
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="newBalance > 21 ? 7 : newBalance <= 5 ? newBalance : 5"
                      v-model="quarterTwo"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{ newBalance > 21 ? 7 : newBalance <= 5 ? newBalance : 5 }}
                    </span>
                  </div>
                </div>
                <!-- Quqrter Three -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Three :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q3_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box" id="q3" v-if="empBalance != 'other...'">
                    <span class="fa fa-edit"></span>
                    <div>{{ quarterThree }} days</div>
                  </div>
                  <div
                    class="cu-input text-box mt-3 mb-3"
                    id="q3input"
                    v-if="empBalance == 'other...'"
                  >
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="newBalance > 21 ? 7 : newBalance <= 5 ? newBalance : 5"
                      v-model="quarterThree"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{ newBalance > 21 ? 7 : newBalance <= 5 ? newBalance : 5 }}
                    </span>
                  </div>
                </div>
                <!-- Quqrter Four -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Four :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q4_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box" id="q4" v-if="empBalance != 'other...'">
                    <span class="fa fa-edit"></span>
                    <div>{{ quarterFour }} days</div>
                  </div>
                  <div
                    class="cu-input text-box mt-3 mb-3"
                    id="q4input"
                    v-if="empBalance == 'other...'"
                  >
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      :min="newBalance > 0 ? 1 : 0"
                      :max="newBalance > 21 ? 9 : newBalance <= 6 ? newBalance : 6"
                      v-model="quarterFour"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be
                      {{ newBalance > 0 ? "at least " + 1 + " and" : "" }}
                      not more than
                      {{ newBalance > 21 ? 9 : newBalance <= 6 ? newBalance : 6 }}
                    </span>
                  </div>
                </div>
                <!-- empty -->
                <div class="cu-field col-md-3 d-sm-none d-none d-md-block"></div>
                <!-- Casual Days -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Casual Days :</label>
                  </h3>
                  <div
                    class="cu-input text-box"
                    id="casual"
                    v-if="empBalance != 'other...'"
                  >
                    <span class="fa fa-edit"></span>
                    <div>{{ casualDays }} days</div>
                  </div>
                  <div
                    class="cu-input text-box mb-3"
                    id="casualInput"
                    v-if="empBalance == 'other...'"
                  >
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="newBalance > 21 ? 7 : newBalance <= 6 ? newBalance : 6"
                      v-model="casualDays"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{ newBalance > 21 ? 7 : newBalance <= 6 ? newBalance : 6 }}
                    </span>
                  </div>
                </div>
                <!-- empty -->
                <div class="cu-field col-md-3 d-sm-none d-none d-md-block"></div>
                <!-- expiration Date -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Expiration Date :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <input
                      type="date"
                      v-model="EmpVacBalance.Old_Balance_ExpirationDate"
                      v-on:keydown.enter.prevent
                    />
                  </div>
                </div>
                <!-- old balance -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Old Balance :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      v-model="EmpVacBalance.Old_Balance"
                      v-on:keydown.enter.prevent
                    />
                  </div>
                </div>
                <!-- submit balance-->
                <div class="cu-field col-md-12 mt-4">
                  <div class="text-center">
                    <button
                      class="special-btn m-0"
                      type="button"
                      @click.prevent="setBalance"
                    >
                      set balance
                    </button>
                  </div>
                </div>
              </div>
            </div>

            <div class="grouped shadow-sm rounded mb-4 d-none" id="display-balance">
              <div class="row">
                <!-- set balance -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Employee Total Balance :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displayTotalBalance }} days</div>
                  </div>
                </div>
                <!-- old balance -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Old Balance :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displayOldBalance }} days</div>
                  </div>
                </div>
                <!-- Quqrter One -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter One :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q1_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displayquarterOne }} days</div>
                  </div>
                </div>
                <!-- Quqrter Two -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Two :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q2_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displayquarterTwo }} days</div>
                  </div>
                </div>
                <!-- Quqrter Three -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Three :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q3_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displayquarterThree }} days</div>
                  </div>
                </div>
                <!-- Quqrter Four -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Four :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q4_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displayquarterFour }} days</div>
                  </div>
                </div>
                <!-- Casual Days -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Casual Days :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displaycasualDays }} days</div>
                  </div>
                </div>
                <!-- expiration Date -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Expiration Date :</label>
                  </h3>
                  <div class="cu-input text-box">
                    <span class="fa fa-edit"></span>
                    <div>{{ displayBalanceExpirationDate }}</div>
                  </div>
                </div>
                <!-- edit balance-->
                <div class="cu-field col-md-12 mt-4">
                  <div class="text-center">
                    <button
                      class="special-btn m-auto"
                      type="button"
                      @click.prevent="showEdid"
                    >
                      edit balance
                    </button>
                  </div>
                </div>
              </div>
            </div>

            <div class="grouped shadow-sm rounded mb-4 d-none" id="edit-balance">
              <div class="row">
                <!-- set balance -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Employee Total Balance :</label>
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      v-model="displayTotalBalance"
                      v-on:keydown.enter.prevent
                    />
                  </div>
                </div>
                <!-- old balance -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Old Balance :</label>
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      v-model="displayOldBalance"
                      v-on:keydown.enter.prevent
                    />
                  </div>
                </div>
                <!-- Quqrter One -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter One :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                      >
                        Ends On {{ EmpVacBalance.Q1_DateTo }}
                      </span>
                    </label>
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 5
                          ? displayTotalBalance
                          : 5
                      "
                      v-model="displayquarterOne"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 5
                          ? displayTotalBalance
                          : 5
                      }}
                    </span>
                  </div>
                </div>
                <!-- Quqrter Two -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Two :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q2_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 5
                          ? displayTotalBalance
                          : 5
                      "
                      v-model="displayquarterTwo"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 5
                          ? displayTotalBalance
                          : 5
                      }}
                    </span>
                  </div>
                </div>
                <!-- Quqrter Three -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Three :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                        >Ends On {{ EmpVacBalance.Q3_DateTo }}</span
                      ></label
                    >
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 5
                          ? displayTotalBalance
                          : 5
                      "
                      v-model="displayquarterThree"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 5
                          ? displayTotalBalance
                          : 5
                      }}
                    </span>
                  </div>
                </div>
                <!-- Quqrter Four -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label
                      >Quarter Four :
                      <span
                        class="text-secondary"
                        style="font-size: 14px; font-weight: bold"
                      >
                        Ends On {{ EmpVacBalance.Q4_DateTo }}
                      </span>
                    </label>
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 6
                          ? displayTotalBalance
                          : 6
                      "
                      v-model="displayquarterFour"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be
                      {{ newBalance > 0 ? "at least " + 1 + " and" : "" }}
                      not more than
                      {{
                        displayTotalBalance > 21
                          ? 9
                          : displayTotalBalance <= 6
                          ? displayTotalBalance
                          : 6
                      }}
                    </span>
                  </div>
                </div>
                <!-- Casual Days -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Casual Days :</label>
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="number"
                      min="0"
                      :max="
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 6
                          ? displayTotalBalance
                          : 6
                      "
                      v-model="displaycasualDays"
                      v-on:keydown.enter.prevent
                    />
                    <span class="text-danger errorMsg">
                      The value must be not more than
                      {{
                        displayTotalBalance > 21
                          ? 7
                          : displayTotalBalance <= 6
                          ? displayTotalBalance
                          : 6
                      }}
                    </span>
                  </div>
                </div>
                <!-- expiration Date -->
                <div class="cu-field col-md-6">
                  <h3 class="cu-label">
                    <label>Expiration Date :</label>
                  </h3>
                  <div class="cu-input text-box mb-3">
                    <span class="fa fa-edit"></span>
                    <input
                      type="date"
                      v-model="displayBalanceExpirationDate"
                      v-on:keydown.enter.prevent
                    />
                  </div>
                </div>
                <!-- edit balance-->
                <div class="cu-field col-md-12 mt-4">
                  <div class="text-center">
                    <button
                      class="special-btn m-auto"
                      type="button"
                      @click.prevent="edidBalance"
                    >
                      submit edit
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "employeeBalance",
  data() {
    return {
      adminusersData: null,
      Employees_Balance: null,

      empBalance: "",
      newBalance: 0,
      quarterOne: 0,
      quarterTwo: 0,
      quarterThree: 0,
      quarterFour: 0,
      casualDays: 0,

      fewBalance: 21,
      larageBalance: 30,

      impId: 0,

      impName: "",
      impDisc: "",
      impBranch: "",
      impDept: "",

      displayTotalBalance: 0,
      displayOldBalance: 0,
      displayquarterOne: 0,
      displayquarterTwo: 0,
      displayquarterThree: 0,
      displayquarterFour: 0,
      displaycasualDays: 0,
      displayBalanceExpirationDate: "",

      EmpVacBalance: {
        Emp_id: 0,
        Annual_Balance: 0,
        Casual_Balance: 0,
        Q1: 1,
        Q1_DateTo: "31-3",
        Q2: 1,
        Q2_DateTo: "31-6",
        Q3: 1,
        Q3_DateTo: "31-9",
        Q4: 1,
        Q4_DateTo: "31-12",
        Old_Balance: 0,
        Old_Balance_ExpirationDate: "",
      },
      apiUrl: "http://localhost:56438/app/dist/",
    };
  },

  methods: {
    showEdid: function () {
      let insertBalance = document.getElementById("insert-balance"),
        editBalance = document.getElementById("edit-balance"),
        displayBalance = document.getElementById("display-balance");

      displayBalance.classList.add("d-none");
      editBalance.classList.remove("d-none");
    },
    edidBalance: function () {
      let that = this;

      if ($("form").is(":valid")) {
        let sum =
            parseInt(this.displayquarterOne) +
            parseInt(this.displayquarterTwo) +
            parseInt(this.displayquarterThree) +
            parseInt(this.displayquarterFour),
          balance = {
            id: this.Employees_Balance.filter((x) => x.Emp_id == this.impId)[0].id,
            Emp_id: this.impId,
            Annual_Balance: this.displayTotalBalance,
            Casual_Balance: this.displaycasualDays,
            Q1: this.displayquarterOne,
            Q2: this.displayquarterTwo,
            Q3: this.displayquarterThree,
            Q4: this.displayquarterFour,
            Old_Balance: this.displayOldBalance,
            Old_Balance_ExpirationDate: this.displayBalanceExpirationDate,
          },
          Newbalance = Object.assign({}, balance);

        if (sum == this.displayTotalBalance) {
          swal({
            title: "Are you sure?",
            buttons: true,
          }).then((confirm) => {
            if (confirm) {
              $.ajax({
                type: "POST",
                url: that.apiUrl + "Hr_Portal/Employee_Balance.aspx/updateDetails",
                data: JSON.stringify({ detail: Newbalance }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                  swal({
                    title: "Sweet!",
                    text: "You successfully updated the employee balance ...",
                    icon: "success",
                    dangerMode: true,
                  });
                },
              });
            }
          });
        } else {
          swal({
            title: "Error!",
            text: "The total balance should be the sum of the four quarters! ",
            icon: "warning",
            dangerMode: true,
          });
        }
      } else {
        swal({
          title: "Not Valid!",
          text: "Please check your inputs! ",
          icon: "warning",
          dangerMode: true,
        });
      }
    },
    setBalance: function () {
      let ObjectD = Object.assign({}, this.EmpVacBalance),
        that = this;

      if (that.impId == 0) {
        swal({
          title: "Error!",
          text: "Sorry you should choose the Employee Id  ! ",
          icon: "warning",
          dangerMode: true,
        });
      } else if (that.empBalance == "" && that.newBalance == 0) {
        swal({
          title: "Error!",
          text: "Sorry you should choose the Employee Total Balance ! ",
          icon: "warning",
          dangerMode: true,
        });
      } else if ($("form").is(":valid")) {
        if (this.empBalance == "other...") {
          if (
            this.newBalance ==
            this.quarterOne + this.quarterTwo + this.quarterThree + this.quarterFour
          ) {
            ObjectD.Annual_Balance = that.newBalance;
            sendData();
          } else {
            swal({
              title: "Error!",
              text: "The total balance should be the sum of the four quarters! ",
              icon: "warning",
              dangerMode: true,
            });
          }
        } else {
          if (this.empBalance == "21 days") {
            ObjectD.Annual_Balance = 21;
          } else if (this.empBalance == "30 days") {
            ObjectD.Annual_Balance = 30;
          }
          sendData();
        }
        function sendData() {
          ObjectD.Emp_id = that.impId;
          ObjectD.Q1 = that.quarterOne;
          ObjectD.Q2 = that.quarterTwo;
          ObjectD.Q3 = that.quarterThree;
          ObjectD.Q4 = that.quarterFour;
          ObjectD.Casual_Balance = that.casualDays;

          $.ajax({
            type: "POST",
            url: that.apiUrl + "Hr_Portal/Employee_Balance.aspx/EmpVacBalance",
            data: JSON.stringify({ Balance: ObjectD }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
              swal({
                title: "Good job!",
                text: "You successfully added an employee vacation balance ...",
                icon: "success",
              }).then((result) => {
                if (result) {
                  window.location = "Employee_Balance.aspx";
                } else {
                  swal({
                    title: "Canceled",
                    text: "Sorry, you can not add employee vacation balance !",
                  });
                }
              });
            },
          });
        }
      } else {
        swal({
          title: "Not Valid!",
          text: "Please check your inputs! ",
          icon: "warning",
          dangerMode: true,
        });
      }
    },
  },

  watch: {
    impId: function () {
      let insertBalance = document.getElementById("insert-balance"),
        editBalance = document.getElementById("edit-balance"),
        displayBalance = document.getElementById("display-balance");

      this.impBranch = this.adminusersData.filter(
        (x) => x.Emp_ID == this.impId
      )[0].Branch_name;
      this.impName = this.adminusersData.filter(
        (x) => x.Emp_ID == this.impId
      )[0].FullName;
      this.impDisc = this.adminusersData.filter(
        (x) => x.Emp_ID == this.impId
      )[0].Job_Description;
      this.impDept = this.adminusersData.filter(
        (x) => x.Emp_ID == this.impId
      )[0].Dept_name;

      if (this.Employees_Balance.filter((x) => x.Emp_id == this.impId).length > 0) {
        displayBalance.classList.remove("d-none");
        editBalance.classList.add("d-none");
        insertBalance.classList.add("d-none");
      } else {
        displayBalance.classList.add("d-none");
        editBalance.classList.add("d-none");
        insertBalance.classList.remove("d-none");
      }

      this.displayTotalBalance = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Annual_Balance;
      this.displayOldBalance = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Old_Balance;
      this.displayquarterOne = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Q1;
      this.displayquarterTwo = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Q2;
      this.displayquarterThree = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Q3;
      this.displayquarterFour = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Q4;
      this.displaycasualDays = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Casual_Balance;
      this.displayBalanceExpirationDate = this.Employees_Balance.filter(
        (x) => x.Emp_id == this.impId
      )[0].Old_Balance_ExpirationDate;
    },
    empBalance: function () {
      if (this.empBalance == "21 days") {
        this.quarterOne = 5;
        this.quarterTwo = 5;
        this.quarterThree = 5;
        this.quarterFour = 6;
        this.casualDays = 6;
      } else if (this.empBalance == "30 days") {
        this.quarterOne = 7;
        this.quarterTwo = 7;
        this.quarterThree = 7;
        this.quarterFour = 9;
        this.casualDays = 7;
      } else {
        this.quarterOne = 0;
        this.quarterTwo = 0;
        this.quarterThree = 0;
        this.quarterFour = 0;
        this.casualDays = 0;
      }
    },
  },

  created: function () {
    let cobject = this;

    //get adminusers
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Employee_Balance.aspx/getadminusersData",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.adminusersData = JSON.parse(data.d);
      },
    });

    //get HR_Employees_Vacation_Balance
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Employee_Balance.aspx/getEmployees_BalanceData",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.Employees_Balance = JSON.parse(data.d);
      },
    });
  },
};
</script>

<style scoped>
.errorMsg {
  position: absolute;
  width: 100% !important;
  bottom: -20px;
  left: 9px;
  opacity: 1;
  transition: all 0.5s ease;
  max-width: 250px;
  line-height: 1.2 !important;
  font-size: 14px;
  display: block;
}
input:valid ~ .errorMsg {
  opacity: 0;
}
</style>
