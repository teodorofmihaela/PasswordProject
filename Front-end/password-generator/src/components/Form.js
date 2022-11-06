import React from 'react';
import { useState } from "react";
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import Item from '@mui/material/Stack';
import { FormGroup } from '@mui/material';
import { Grid } from '@mui/material';
import { InputAdornment } from '@mui/material';
import TextField from '@mui/material/TextField';
import { AccountCircle } from '@mui/icons-material';
import PasswordIcon from '@mui/icons-material/Password';
import VisibilityIcon from '@mui/icons-material/Visibility';
import { Card } from '@mui/material';
import { Typography } from '@mui/material';
import Alert from '@mui/material/Alert';
import AutorenewIcon from '@mui/icons-material/Autorenew';
import LoginIcon from '@mui/icons-material/Login';
import PixIcon from '@mui/icons-material/Pix';
import Fade from "@mui/material/Fade";
import AlertTitle from "@mui/material/AlertTitle";
import "./Form.css";

function Form() {

    const [passwordChange, setPasswordChange] = useState({
        initialPassword: "Your Password will be here"
    });

    const [showPassword, setShowPassword] = useState(false);

    const [passwordInput, setPasswordInput] = useState();
    const [userIdInput, setUserIdInput] = useState();

    const [showAlert, setShowAlert] = React.useState(false);
    const [showLoginAlert, setShowLoginAlert] = React.useState(false);
    const [alertLoginVisibility, setAlertLoginVisibility] = useState(false);
    const [alertPasswordVisibility, setAlertPasswordVisibility] = useState(false);

    var password;
    var messagePassword = " Wait 30 second for a new generated password!";

    async function generatePassword() {

        try {
            const baseURL = "http://localhost:5232";

            const encodedValue = encodeURIComponent(userIdInput);
            const res = await fetch(`${baseURL}/password?userId=${encodedValue}`, {
                method: "GET",
                datatype: "json"
            });
            console.log(res);

            if (res.status === 204) {
                setAlertPasswordVisibility(true);
                setShowAlert(true);
                const message = `Wait 30s for a new password, response: ${res.status} - ${res.statusText}`;
                throw new Error(message);
            } else {
                setShowAlert(false);
            }

            const data = await res.json();


            const result = {
                data: data,
                status: res.status,
                statusText: res.statusText,
            };
            console.log(result.statusText);
            password = data['password'];
            console.log(password);

            changeInitialPassword();


        }
        catch (err) {
            console.log(err);
        }
    }

    async function login() {
        try {
            const baseURL = "http://localhost:5232";

            const res = await fetch(`${baseURL}/login`, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "post",
                body: JSON.stringify({
                    "UserId": userIdInput,
                    "Password": passwordInput
                })
            });

            const data = await res.json();

            console.log(data);

            if (data == true) {
                //     setTimeout(() => {

                //   }, 3000);
                setShowLoginAlert(true);
                setAlertLoginVisibility(true);
                const message = `Login successful, response: ${res.status} - ${res.statusText}`;
                console.log(message);
            }
            else {
                setShowLoginAlert(false);
                setAlertLoginVisibility(true);
                const message = `Login failed, response: ${res.status} - ${res.statusText}`;
                console.log(message);
            }
        }
        catch (err) {
            console.log(err);
        }
    }

    //show generated password 

    function changeInitialPassword() {
        setPasswordChange({
            ...passwordChange,
            initialPassword: password
        });
    }


    function onReset() {
        setPasswordInput("");
        setUserIdInput("");
    }


    return (
        <FormGroup id="page" >
            <Grid id="form">
                <Stack spacing={5}>
                    <Item>
                        <Typography variant="h4">My password generator</Typography>
                    </Item>
                    <Item>
                        <Stack spacing={3}>
                            <div>
                                <AccountCircle className='form-icon' fontSize='large' />
                                <TextField className="input" value={userIdInput} size="small" style={{ width: "250px" }}
                                    onChange={event => setUserIdInput(event.target.value)}
                                    label="User id" variant="outlined"
                                    helperText="Enter your id to generate a one time password">
                                </TextField>
                            </div>
                            <div style={{ marginLeft: "20px" }}>
                                <Button variant="contained" onClick={generatePassword}>Generate password<PixIcon style={{ paddingLeft: "7px" }} /></Button>
                            </div>
                            <div>
                                <PasswordIcon className='form-icon' fontSize='large' />
                                <TextField className="input" size="small"
                                    type={showPassword ? "text" : "password"}
                                    value={passwordInput} onChange={event => setPasswordInput(event.target.value)} label="Password" variant="outlined"
                                    InputProps={{
                                        endAdornment: <InputAdornment position="end">
                                            <IconButton onClick={() => setShowPassword(s => !s)} style={{ color: "#a742f5" }} >
                                                <VisibilityIcon />
                                            </IconButton >
                                        </InputAdornment>,
                                    }}>
                                </TextField>
                            </div>
                            <Item>
                                <div>
                                    <Button variant="contained" onClick={login}>Login <LoginIcon style={{ paddingLeft: "7px" }} /></Button>
                                    <Button variant="contained" onClick={onReset}>Reset <AutorenewIcon style={{ paddingLeft: "7px" }} /></Button>
                                </div>
                            </Item>
                            <div>
                                <Fade
                                    in={alertLoginVisibility} //Write the needed condition here to make it appear
                                    timeout={{ enter: 1000, exit: 1000 }} //Edit these two values to change the duration of transition when the element is getting appeared and disappeard
                                    addEndListener={() => {
                                        setTimeout(() => {
                                            setAlertLoginVisibility(false)
                                        }, 2000);
                                    }}>
                                    {showLoginAlert ?
                                        <Alert severity="success" className="alert">
                                            <AlertTitle>Success</AlertTitle>
                                            Registration Successful!
                                        </Alert> :
                                        <Alert severity="error" className="alert">
                                            <AlertTitle>Failed</AlertTitle>
                                            Registration Not Successful!
                                        </Alert>}
                                </Fade>

                            </div>
                            <Item id="card">
                                <Card>
                                    <Fade
                                        in={alertPasswordVisibility} //Write the needed condition here to make it appear
                                        timeout={{ enter: 1000, exit: 1000 }} //Edit these two values to change the duration of transition when the element is getting appeared and disappeard
                                        addEndListener={() => {
                                            setTimeout(() => {
                                                setAlertPasswordVisibility(false)
                                            }, 2000);
                                        }}
                                    >
                                        {showAlert ? <Alert severity="error">
                                            {messagePassword}</Alert> : <Alert severity="success">Success!</Alert>}
                                    </Fade>
                                    <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom> Your one time password is:
                                    </Typography>
                                    <Typography variant="h5" component="div" >
                                        {passwordChange.initialPassword}
                                    </Typography>
                                    <Typography sx={{ mb: 1.5 }} color="text.secondary">Hurry! It expiers in 30 seconds!
                                    </Typography>
                                </Card>
                            </Item>
                        </Stack>
                    </Item>
                </Stack>
            </Grid>
        </FormGroup>
    );
}

export default Form;