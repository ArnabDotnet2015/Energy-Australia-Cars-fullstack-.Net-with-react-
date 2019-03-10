const dev = {
    apiBaseUrl: 'https://localhost:44394/'
}

const prod = {
    apiBaseUrl: 'This is prod url'
}

const config = process.env.REACT_APP_STAGE === 'production'
    ? prod
    : dev;

export default {
    ...config
}